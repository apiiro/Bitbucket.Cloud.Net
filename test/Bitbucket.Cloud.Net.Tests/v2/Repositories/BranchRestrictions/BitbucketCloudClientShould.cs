﻿using System.Linq;
using System.Threading.Tasks;
using Xunit;

// ReSharper disable once CheckNamespace
namespace Bitbucket.Cloud.Net.Tests
{
	public partial class BitbucketCloudClientShould
	{
		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryBranchRestrictionsAsync(string workspaceId, string repositorySlug)
		{
			var result = await _client.GetRepositoryBranchRestrictionsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			Assert.NotNull(result);
		}

		[Theory]
		[InlineData("luve", "test")]
		public async Task GetRepositoryBranchRestrictionAsync(string workspaceId, string repositorySlug)
		{
			var results = await _client.GetRepositoryBranchRestrictionsAsync(workspaceId, repositorySlug).ConfigureAwait(false);
			var firstResult = results.FirstOrDefault();
			if (firstResult == null)
			{
				return;
			}

			var result = await _client.GetRepositoryBranchRestrictionAsync(workspaceId, repositorySlug, firstResult.Id.ToString()).ConfigureAwait(false);
			Assert.NotNull(result);
		}
	}
}
