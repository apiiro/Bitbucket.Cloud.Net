﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Bitbucket.Cloud.Net.Common;
using Bitbucket.Cloud.Net.Common.Authentication;
using Bitbucket.Cloud.Net.Common.Models;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bitbucket.Cloud.Net
{
	public partial class BitbucketCloudClient
	{
		private static readonly ISerializer s_serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

		private readonly Url _url;
		private readonly AuthenticationMethod _auth;

		private BitbucketCloudClient(string url)
		{
			_url = url;
		}

		public BitbucketCloudClient(string url, OAuthAuthentication oauth)
			: this(url)
		{
			_auth = oauth;
		}

		public BitbucketCloudClient(string url, AppPasswordAuthentication appPassword)
			: this(url)
		{
			_auth = appPassword;
		}

		public BitbucketCloudClient(string url, BasicAuthentication basic)
			: this(url)
		{
			_auth = basic;
		}

		public IFlurlRequest GetBaseUrl(string path) => new Url(_url)
			.AppendPathSegment(path)
			.ConfigureRequest(settings => settings.JsonSerializer = s_serializer)
			.WithAuthentication(_auth);

		private async Task<TResult> ReadResponseContentAsync<TResult>(IFlurlResponse responseMessage, Func<string, TResult> contentHandler = null)
		{
			string content = await responseMessage.GetStringAsync().ConfigureAwait(false);
			return contentHandler != null
				? contentHandler(content)
				: JsonConvert.DeserializeObject<TResult>(content);
		}

		private async Task<bool> ReadResponseContentAsync(IFlurlResponse responseMessage)
		{
			string content = await responseMessage.GetStringAsync().ConfigureAwait(false);
			return content.Length == 0;
		}

		private async Task HandleErrorsAsync(IFlurlResponse response)
		{
			if (response.StatusCode >= 300)
			{
				var errorResponse = await ReadResponseContentAsync<ErrorResponse>(response).ConfigureAwait(false);

				string errorMessage = string.Join(Environment.NewLine, errorResponse?.Error?.Message);
				throw new InvalidOperationException($"Http request failed ({(int)response.StatusCode} - {response.StatusCode}):\n{errorMessage}");
			}
		}

		private async Task<TResult> HandleResponseAsync<TResult>(IFlurlResponse responseMessage, Func<string, TResult> contentHandler = null)
		{
			await HandleErrorsAsync(responseMessage).ConfigureAwait(false);
			return await ReadResponseContentAsync(responseMessage, contentHandler).ConfigureAwait(false);
		}

		private async Task<bool> HandleResponseAsync(IFlurlResponse responseMessage)
		{
			await HandleErrorsAsync(responseMessage).ConfigureAwait(false);
			return await ReadResponseContentAsync(responseMessage).ConfigureAwait(false);
		}

		private async Task<IEnumerable<T>> GetPagedResultsAsync<T>(int? maxPages, IDictionary<string, object> queryParamValues, Func<IDictionary<string, object>, Task<PagedResults<T>>> selector)
		{
			var results = new List<T>();
			bool isLastPage = false;
			int numPages = 0;

			while (!isLastPage && (maxPages == null || numPages < maxPages))
			{
				var selectorResults = await selector(queryParamValues).ConfigureAwait(false);
				selectorResults.Page = Math.Max(selectorResults.Page, 1);
				results.AddRange(selectorResults.Values);

				isLastPage = selectorResults.Next == null || selectorResults.Size == numPages * selectorResults.PageLen;
				if (!isLastPage)
				{
					queryParamValues["page"] = selectorResults.Page + 1;
				}

				numPages++;
			}

			return results;
		}
	}
}
