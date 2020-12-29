![Icon](https://i.imgur.com/OsDAzyV.png)
# Bitbucket.Cloud.Net 
[![Build status](https://ci.appveyor.com/api/projects/status/e6syxlce88nlg75d?svg=true)](https://ci.appveyor.com/project/lvermeulen/bitbucket-cloud-net)
 [![license](https://img.shields.io/github/license/lvermeulen/Bitbucket.Cloud.Net.svg?maxAge=2592000)](https://github.com/lvermeulen/Bitbucket.Cloud.Net/blob/master/LICENSE) [![NuGet](https://img.shields.io/nuget/v/Bitbucket.Cloud.Net.svg?maxAge=2592000)](https://www.nuget.org/packages/Bitbucket.Cloud.Net/) 
 ![](https://img.shields.io/badge/.net-4.6-yellowgreen.svg) ![](https://img.shields.io/badge/netstandard-1.6-yellowgreen.svg)

C# Client for Bitbucket Cloud

Documentation is at [https://developer.atlassian.com/bitbucket/api/2/reference/](https://developer.atlassian.com/bitbucket/api/2/reference/).

If you're looking for Bitbucket Server API, try [this repository](https://github.com/lvermeulen/Bitbucket.Net).

## Nuget instructions
This package is managed with Nuget, in order to update it, follow the next steps.

```
dotnet pack --configuration Release
dotnet nuget push src/Bitbucket.Cloud.Net/bin/Release/Apiiro.BitbucketCloud.1.0.0.nupkg --source "github" --skip-duplicate --no-symbols true
```

## Features
* [X] Authentication
    * [X] OAuth2
    * [X] App Passwords
    * [X] Basic
* [X] 1.0
    * [X] Group Privileges
    * [X] Groups
    * [X] Invitations
    * [X] Users
        * [X] Invitations
* [X] 2.0
    * [X] Hook Events
        * [X] Subject Type
    * [X] Pull Requests
        * [X] Selected User
    * [X] Repositories
        * [X] Workspace
            * [X] Repo Slug
                * [X] Branch Restrictions
                    * [X] Id
                * [X] Branching Model
                    * [X] Settings
                * [X] Commit
                    * [X] Commit
                        * [X] Properties
                            * [X] App Key
                                * [X] Property Name
                    * [X] Node
                        * [X] Approve
                        * [X] Comments
                            * [X] Comment Id
                        * [X] Statuses
                            * [X] Build
                                * [X] Key
                * [X] Commits
                    * [X] Revision
                * [X] Components
                    * [X] Component Id
                * [X] Default Reviewers
                    * [X] Target User Name
                * [X] Deploy Keys
                    * [X] Key Id
                * [X] Deployments
                    * [X] Deployment Uuid
                * [X] Deployments Config
                    * [X] Environments
                        * [X] Environment Uuid
                            * [X] Variables
                                * [X] Variable Uuid
                * [X] Diff
                    * [X] Spec
                * [X] Diffstat
                    * [X] Spec
                * [X] Downloads
                    * [X] Filename
                * [X] Environments
                    * [X] Environment Uuid
                        * [X] Changes
                * [X] File History
                    * [X] Node
                        * [X] Path
                * [X] Forks
                * [X] Hooks
                    * [X] Uid
                * [X] Issues
                    * [X] Export
                    * [X] Import
                    * [X] Issue Id
                        * [X] Attachments
                            * [X] Path
                        * [X] Changes
                            * [X] Change Id
                        * [X] Comments
                            * [X] Comment Id
                        * [X] Vote
                        * [X] Watch
                * [X] Milestones
                    * [X] Milestone Id
                * [X] Patch
                    * [X] Spec
                * [X] Pipelines
                    * [X] Pipeline Uuid
                        * [X] Steps
                            * [X] Step Uuid
                                * [X] Log
                                    * [X] Log Uuid
                                * [X] Test Reports
                                    * [X] Test Cases
                                        * [X] Test Case Uuid
                                            * [X] Test Case Reasons
                        * [X] Stop Pipeline
                * [X] Pipelines Config
                    * [X] Build Number
                    * [X] Schedules
                        * [X] Schedule Uuid
                            * [X] Executions
                    * [X] Ssh
                        * [X] Key Pair
                        * [X] Known Hosts
                            * [X] Known Host Uuid
                    * [X] Variables
                        * [X] Variable Uuid
                * [X] Properties
                    * [X] App Key
                        * [X] Property Name
                * [X] Pull Requests
                    * [X] Activity
                    * [X] Pull Request Id
                        * [X] Activity
                        * [X] Approve
                        * [X] Comments
                        * [X] Commits
                        * [X] Decline
                        * [X] Diff
                        * [X] Diffstat
                        * [X] Merge
                        * [X] Patch
                        * [X] Statuses
                        * [X] Properties
                            * [X] App Key
                                * [X] Property Name
                * [X] Refs
                    * [X] Branches
                        * [X] Name
                    * [X] Tags
                        * [X] Name
                * [X] Src
                    * [X] Node
                        * [X] Path
                * [X] Versions
                    * [X] Version Id
                * [X] Watchers
    * [X] Snippets
        * [X] Workspace
            * [X] Encoded Id
                * [X] Comments
                    * [X] Comment Id
                * [X] Commits
                    * [X] Revision
                * [X] Files
                    * [X] Path
                * [X] Watch
                * [X] Watchers
                * [X] Node Id
                    * [X] Files
                        * [X] Path
                * [X] Revision
                    * [X] Diff
                    * [X] Patch
    * [X] Teams
        * [X] User Name
            * [X] Followers
            * [X] Following
            * [X] Hooks
                * [X] Uid
            * ~~[X] Members~~ (deprecated)
            * [X] Permissions
                * [X] Repositories
                    * [X] Repo Slug
            * [X] Pipelines Config
                * [X] Variables
                    * [X] Variable Uuid
            * [X] Projects
                * [X] Project Key
            * [X] Repositories
            * [X] Search
                * [X] Code
    * [X] User
        * [X] Emails
            * [X] Email
        * [X] Permissions
            * [X] Repositories
            * [X] Teams
    * [X] Users
        * [X] User Name
            * ~~[X] Followers~~ (deprecated)
            * ~~[X] Following~~ (deprecated)
            * [X] Hooks
                * [X] Uid
            * ~~[X] Members~~ (deprecated)
            * [X] Pipelines Config
                * [X] Variables
                    * [X] Variable Uuid
            * [X] Repositories
            * [X] Search
                * [X] Code
            * [X] Ssh Keys
