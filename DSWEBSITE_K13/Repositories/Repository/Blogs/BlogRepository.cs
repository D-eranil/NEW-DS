using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;
using CMS.SiteProvider;
using DSWEBSITE_K13.Components.ViewComponents;
using DSWEBSITE_K13.Libraries.Infrastructure;
using DSWEBSITE_K13.Models.ViewModels;
using Kentico.Content.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DSWEBSITE_K13.Repositories.Repository
{
    public class BlogRepository //: IBlogRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly RepositoryCacheHelper repositoryCacheHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeRepository"/> class that returns home page sections. 
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public BlogRepository(IPageRetriever pageRetriever,
            RepositoryCacheHelper _repositoryCacheHelper)
        {
            this.pageRetriever = pageRetriever;
            this.repositoryCacheHelper = _repositoryCacheHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BlogContainerModel GetHomePageBlogs()
        {
            try
            {

                string[] cols = { "Name", "BlogHeading", "BlogImage", "BlogTitle", "BlogImageAltText", "ShortTitle", "BlogContentText", "BlogAuthor", "BlogCreatedDate", "BlogReadTimeText", "BlogCreatedDate", "IsActive", "NodeAliasPath", "DocumentModifiedWhen" };

                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var blogList = new List<Blogs>();
                var blogs = new BlogContainerModel();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    blogList = pageRetriever.RetrieveAsync<Blogs>(
                        query => query

                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .TopN(5)
                             .Where("IsActive=1")
                            .OrderByDescending("DocumentModifiedWhen")
                            .ToList())?.Result.ToList();
                    //related = Enumerable.Cast<BannerSection>(data.Result);
                }
                else
                {
                    blogList = pageRetriever.RetrieveAsync<Blogs>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .TopN(5)
                             .Where("IsActive=1")
                            .OrderByDescending("DocumentModifiedWhen")
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(BlogRepository)}|{nameof(GetHomePageBlogs)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();

                }

                if (blogList != null && blogList.Count > 0)
                {
                    blogs.Controls = new BlogControlsViewModel();
                    blogs.Blogs = new List<BlogViewModel>();
                    foreach (var blog in blogList)
                    {
                        blogs.Controls = GetHeadings();
                        blogs.Blogs.Add(BlogViewModel.GetModel(blog));
                    }
                }

                return blogs;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "100000013", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public BlogListContainerModel GetBlogList(string category, string tag)
        {
            string noblogmessage = SettingsKeyInfoProvider.GetValue("NoBlogMessage");

            var blogList = new BlogListContainerModel();
            try
            {
                //latest one blog
                blogList.LatestBlog = new LatestBlogViewModel();
                blogList.Blogs = new List<BlogListViewModel>();

                blogList.IsCategorySearch = !string.IsNullOrEmpty(category);
                blogList.IsTagSearch = !string.IsNullOrEmpty(tag);

                //bind latest blog
                var _latestBlog = new LatestBlogViewModel();
                var _blogList = new List<BlogListViewModel>();
                //bind blog banner
                if (!string.IsNullOrEmpty(category))
                {
                    //latest
                    _latestBlog = GetLatestBlogByCategory(category);
                    //list
                    _blogList = GetBlogsByCategory(category, _latestBlog.NodeAliasPath);
                }
                else if (!string.IsNullOrEmpty(tag))
                {
                    //latest
                    _latestBlog = GetLatestBlogByTag(tag);
                    //list
                    _blogList = GetBlogsByTag(tag, _latestBlog.NodeAliasPath);
                }
                else
                {
                    //latest
                    _latestBlog = GetLatestBlog();
                    //list
                    _blogList = GetBlogs(_latestBlog.NodeAliasPath);
                }

                if (_latestBlog != null)
                {
                    blogList.LatestBlog = _latestBlog;
                }
                if (_blogList != null && _blogList.Count > 0)
                {

                    blogList.Blogs = _blogList;
                }

                blogList.Controls = new BlogControlsViewModel();
                var controls = GetHeadings();
                if (controls != null)
                    blogList.Controls = controls;

                blogList.Message = string.Empty;

                if (blogList.Blogs != null && blogList.Blogs.Count <= 0)
                    blogList.Message = noblogmessage;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "100000011", ex.Message);
            }
            return blogList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BlogDetailsViewModel GetSelectedBlog(int nodeId)
        {
            try
            {
                string[] cols = { "BlogsID", "Name", "BlogHeading", "BlogDetailImage", "BlogDetailImageAltText", "BlogAuthor", "BlogTopic", "BlogCreatedDate", "ShortTitle", "BlogTitle", "BlogContentText", "BlogDetailContent", "BlogBannerImage", "BlogBannerImageAltText", "Category", "Tag", "IsActive", "NodeID", "NodeAliasPath", "DocumentModifiedWhen" };

                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var blog = new Blogs();
                var _blog = new BlogDetailsViewModel();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    blog = pageRetriever.RetrieveAsync<Blogs>(
                        query => query

                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .WhereEquals("NodeID", nodeId)
                             .WhereEquals("IsActive", true)
                             .OrderByDescending("DocumentModifiedWhen")
                            .FirstOrDefault())?.Result.FirstOrDefault();
                }
                else
                {
                    blog = pageRetriever.RetrieveAsync<Blogs>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .WhereEquals("NodeID", nodeId)
                             .WhereEquals("IsActive", true)
                             .OrderByDescending("DocumentModifiedWhen")
                            .FirstOrDefault(),
                        cache => cache
                            .Key($"{nameof(BlogRepository)}|{nameof(GetSelectedBlog)}|{nodeId}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Single).PageOrder()),
                        new CancellationToken())?.Result.FirstOrDefault();
                }

                if (blog != null)
                {
                    _blog = BlogDetailsViewModel.GetModel(blog);
                }
                return _blog;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "100000010", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeAliasPath"></param>
        /// <returns></returns>
        public BlogDetailsModel GetSelectedBlog(string nodeAliasPath)
        {
            try
            {
                string[] cols = { "BlogsID", "Name", "BlogHeading", "BlogDetailImage", "BlogDetailImageAltText", "BlogAuthor", "BlogTopic", "BlogCreatedDate", "ShortTitle", "BlogTitle", "BlogContentText", "BlogDetailContent", "BlogBannerImage", "BlogBannerImageAltText", "Category", "Tag", "IsActive", "NodeID", "NodeAliasPath", "DocumentModifiedWhen" };

                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var blog = new Blogs();
                var blogDetails = new BlogDetailsModel();
                var _blog = new BlogDetailsViewModel();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    blog = pageRetriever.RetrieveAsync<Blogs>(
                        query => query

                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .Path(nodeAliasPath, PathTypeEnum.Single)
                             .WhereEquals("IsActive", true)
                             .OrderByDescending("DocumentModifiedWhen")
                            .FirstOrDefault())?.Result.FirstOrDefault();
                }
                else
                {
                    blog = pageRetriever.RetrieveAsync<Blogs>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .Path(nodeAliasPath, PathTypeEnum.Single)
                             .WhereEquals("IsActive", true)
                             .OrderByDescending("DocumentModifiedWhen")
                            .FirstOrDefault(),
                        cache => cache
                            .Key($"{nameof(BlogRepository)}|{nameof(GetSelectedBlog)}|{nodeAliasPath}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath(nodeAliasPath, PathTypeEnum.Single).PageOrder()),
                        new CancellationToken())?.Result.FirstOrDefault();
                }
                //bind selected blog
                if (blog != null)
                {
                    blogDetails.SelectedBlog = BlogDetailsViewModel.GetModel(blog);
                }
                //bind related blogs
                var _latestBlogs = GetRelatedBlogs(blog.Category, nodeAliasPath);
                if (_latestBlogs != null && _latestBlogs.Count > 0)
                {
                    blogDetails.LatestBlogs = _latestBlogs;
                }
                
                blogDetails.Controls = GetHeadings();

                return blogDetails;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "10000009", ex.Message);
                throw ex;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BlogBannerViewModel GetBlogBanner()
        {
            try
            {
                string[] cols = { "Name", "Heading", "SubHeading", "BannerImage", "BannerImageAltText", "IsActive" };


                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var banner = new BlogBanner();
                var _banner = new BlogBannerViewModel();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    banner = pageRetriever.RetrieveAsync<BlogBanner>(
                        query => query

                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .Where(x => x.IsActive == true)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList())?.Result.FirstOrDefault();
                    //related = Enumerable.Cast<BannerSection>(data.Result);
                }
                else
                {
                    banner = pageRetriever.RetrieveAsync<BlogBanner>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .Where(x => x.IsActive == true)
                            .OrderByDescending(x => x.DocumentCreatedWhen)
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(BlogRepository)}|{nameof(GetBlogBanner)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.FirstOrDefault();
                }

                if (banner != null)
                {
                    _banner = BlogBannerViewModel.GetModel(banner);
                }

                return _banner;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "10000008", ex.Message);
                throw ex;
            }
        }

        #region private method's

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private LatestBlogViewModel GetLatestBlog()
        {
            try
            {
                string[] cols = { "Name","BlogHeading","BlogDetailImage","BlogDetailImageAltText",
                    "ShortTitle","BlogTitle", "BlogContentText", "BlogAuthor","BlogTopic", "BlogCreatedDate", "IsActive","Category", "Tag", "BlogBannerImage","BlogBannerImageAltText", "NodeAliasPath", "DocumentModifiedWhen" };

                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var blog = new Blogs();
                var _blog = new LatestBlogViewModel();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    blog = pageRetriever.RetrieveAsync<Blogs>(
                        query => query

                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                            .TopN(1)
                            .OrderByDescending("DocumentModifiedWhen")
                            .ToList())?.Result.FirstOrDefault();
                    //related = Enumerable.Cast<BannerSection>(data.Result);
                }
                else
                {
                    blog = pageRetriever.RetrieveAsync<Blogs>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .TopN(1)
                            .OrderByDescending("DocumentModifiedWhen")
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(BlogRepository)}|{nameof(GetLatestBlog)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.FirstOrDefault();

                }

                if (blog != null)
                {
                    _blog = LatestBlogViewModel.GetModel(blog);
                }
                return _blog;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "10000007", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        private LatestBlogViewModel GetLatestBlogByCategory(string category)
        {
            try
            {
                string[] cols = { "Name","BlogHeading","BlogDetailImage","BlogDetailImageAltText",
                    "ShortTitle","BlogTitle", "BlogContentText", "BlogAuthor","BlogTopic", "BlogCreatedDate", "IsActive","Category", "Tag", "BlogBannerImage","BlogBannerImageAltText", "NodeAliasPath", "DocumentModifiedWhen" };

                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var blog = new Blogs();
                var _blog = new LatestBlogViewModel();

                if (!string.IsNullOrWhiteSpace(category))
                {

                    if (!enableCache)
                    {
                        //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                        blog = pageRetriever.RetrieveAsync<Blogs>(
                            query => query

                                .Published(true)
                                .OnSite(SiteContext.CurrentSiteName)
                                 .Columns(cols)
                                .TopN(1)
                                 .WhereEquals("Category", category)
                                 .WhereEquals("IsActive", true)
                                .OrderByDescending("DocumentModifiedWhen")
                                .ToList())?.Result.FirstOrDefault();
                        //related = Enumerable.Cast<BannerSection>(data.Result);
                    }
                    else
                    {
                        blog = pageRetriever.RetrieveAsync<Blogs>(
                            query => query
                                .Published(true)
                                .OnSite(SiteContext.CurrentSiteName)
                                 .Columns(cols)
                                 .TopN(1)
                                  .WhereEquals("Category", category)
                                 .WhereEquals("IsActive", true)
                                .OrderByDescending("DocumentModifiedWhen")
                                .ToList(),
                            cache => cache
                                .Key($"{nameof(BlogRepository)}|{nameof(GetLatestBlogByCategory)}|{category}")
                                // Include path dependency to flush cache when a new child page is created or page order is changed.
                                .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                            new CancellationToken())?.Result.FirstOrDefault();

                    }
                }
                if (blog != null)
                {
                    _blog = LatestBlogViewModel.GetModel(blog);
                }
                return _blog;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "10000007", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        private LatestBlogViewModel GetLatestBlogByTag(string tag)
        {
            try
            {
                string[] cols = { "Name", "BlogHeading","BlogDetailImage","BlogDetailImageAltText",
                    "ShortTitle","BlogTitle", "BlogContentText", "BlogAuthor","BlogTopic", "BlogCreatedDate", "IsActive","Category", "Tag", "BlogBannerImage","BlogBannerImageAltText", "NodeAliasPath", "DocumentModifiedWhen" };

                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var blog = new Blogs();
                var _blog = new LatestBlogViewModel();

                if (!string.IsNullOrWhiteSpace(tag))
                {

                    if (!enableCache)
                    {
                        //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                        blog = pageRetriever.RetrieveAsync<Blogs>(
                            query => query

                                .Published(true)
                                .OnSite(SiteContext.CurrentSiteName)
                                 .Columns(cols)
                                .TopN(1)
                                 .WhereContains("Tag", tag)
                                 .WhereEquals("IsActive", true)
                                .OrderByDescending("DocumentModifiedWhen")
                                .ToList())?.Result.FirstOrDefault();
                        //related = Enumerable.Cast<BannerSection>(data.Result);
                    }
                    else
                    {
                        blog = pageRetriever.RetrieveAsync<Blogs>(
                            query => query
                                .Published(true)
                                .OnSite(SiteContext.CurrentSiteName)
                                 .Columns(cols)
                                 .TopN(1)
                                  .WhereContains("Tag", tag)
                                 .WhereEquals("IsActive", true)
                                .OrderByDescending("DocumentModifiedWhen")
                                .ToList(),
                            cache => cache
                                .Key($"{nameof(BlogRepository)}|{nameof(GetLatestBlogByTag)}|{tag}")
                                // Include path dependency to flush cache when a new child page is created or page order is changed.
                                .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                            new CancellationToken())?.Result.FirstOrDefault();

                    }
                }
                if (blog != null)
                {
                    _blog = LatestBlogViewModel.GetModel(blog);
                }
                return _blog;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "10000006", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<BlogListViewModel> GetBlogs(string nodeAliasPath)
        {
            try
            {
                string[] cols = { "BlogsID", "Name", "BlogHeading", "ThumbnailImage", "ThumbnailImageAltText", "BlogAuthor", "BlogTopic", "BlogCreatedDate", "ShortTitle", "BlogTitle", "BlogContentText", "IsActive", "NodeID", "Category", "Tag", "NodeAliasPath", "DocumentModifiedWhen" };


                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var blogs = new List<Blogs>();
                var _blogs = new List<BlogListViewModel>();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    blogs = pageRetriever.RetrieveAsync<Blogs>(
                        query => query

                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                            .TopN(9)
                             .Columns(cols)
                             .WhereNotEquals("NodeAliasPath", nodeAliasPath)
                             .WhereEquals("IsActive", true)
                            .OrderByDescending("DocumentModifiedWhen")
                            .ToList())?.Result.ToList();
                    //related = Enumerable.Cast<BannerSection>(data.Result);
                }
                else
                {
                    blogs = pageRetriever.RetrieveAsync<Blogs>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                            .TopN(9)
                             .Columns(cols)
                             .WhereNotEquals("NodeAliasPath", nodeAliasPath)
                             .WhereEquals("IsActive", true)
                            .OrderByDescending("DocumentModifiedWhen")
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(BlogRepository)}|{nameof(GetBlogs)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();
                }
                if (blogs != null && blogs.Count > 0)
                {
                    foreach (var blog in blogs)
                    {
                        _blogs.Add(BlogListViewModel.GetModel(blog));
                    }
                }
                return _blogs;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "10000005", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        private List<BlogListViewModel> GetBlogsByCategory(string category, string nodeAliasPath)
        {
            try
            {
                string[] cols = { "BlogsID", "Name", "BlogHeading", "ThumbnailImage", "ThumbnailImageAltText", "BlogAuthor", "BlogTopic", "BlogCreatedDate", "ShortTitle", "BlogTitle", "BlogContentText", "IsActive", "NodeID", "Category", "Tag", "DocumentModifiedWhen" };


                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var blogs = new List<Blogs>();
                var _blogs = new List<BlogListViewModel>();
                if (!string.IsNullOrWhiteSpace(category))
                {
                    if (!enableCache)
                    {
                        //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                        blogs = pageRetriever.RetrieveAsync<Blogs>(
                            query => query

                                .Published(true)
                                .OnSite(SiteContext.CurrentSiteName)
                                .TopN(9)
                                 .Columns(cols)
                                  .WhereNotEquals("NodeAliasPath", nodeAliasPath)
                                  .WhereEquals("Category", category)
                                 .WhereEquals("IsActive", true)
                                .OrderByDescending("DocumentModifiedWhen")
                                .ToList())?.Result.ToList();
                        //related = Enumerable.Cast<BannerSection>(data.Result);
                    }
                    else
                    {
                        blogs = pageRetriever.RetrieveAsync<Blogs>(
                            query => query
                                .Published(true)
                                .OnSite(SiteContext.CurrentSiteName)
                                .TopN(9)
                                 .Columns(cols)
                                 .WhereNotEquals("NodeAliasPath", nodeAliasPath)
                                  .WhereEquals("Category", category)
                                 .WhereEquals("IsActive", true)
                                .OrderByDescending("DocumentModifiedWhen")
                                .ToList(),
                            cache => cache
                                .Key($"{nameof(BlogRepository)}|{nameof(GetBlogsByCategory)}|{category}")
                                // Include path dependency to flush cache when a new child page is created or page order is changed.
                                .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                            new CancellationToken())?.Result.ToList();
                    }
                }

                if (blogs != null && blogs.Count > 0)
                {
                    foreach (var blog in blogs)
                    {
                        _blogs.Add(BlogListViewModel.GetModel(blog));
                    }
                }
                return _blogs;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "10000004", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        private List<BlogListViewModel> GetBlogsByTag(string tag, string nodeAliasPath)
        {
            try
            {
                string[] cols = { "BlogsID", "Name", "BlogHeading", "ThumbnailImage", "ThumbnailImageAltText", "BlogAuthor", "BlogTopic", "BlogCreatedDate", "ShortTitle", "BlogTitle", "BlogContentText", "IsActive", "NodeID", "Category", "Tag", "DocumentModifiedWhen" };


                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var blogs = new List<Blogs>();
                var _blogs = new List<BlogListViewModel>();
                if (!string.IsNullOrWhiteSpace(tag))
                {
                    if (!enableCache)
                    {
                        //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                        blogs = pageRetriever.RetrieveAsync<Blogs>(
                            query => query

                                .Published(true)
                                .OnSite(SiteContext.CurrentSiteName)
                                .TopN(9)
                                 .Columns(cols)
                                 .WhereContains("Tag", tag)
                                 .WhereNotEquals("NodeAliasPath", nodeAliasPath)
                                 .WhereEquals("IsActive", true)
                                .OrderByDescending("DocumentModifiedWhen")
                                .ToList())?.Result.ToList();
                        //related = Enumerable.Cast<BannerSection>(data.Result);
                    }
                    else
                    {
                        blogs = pageRetriever.RetrieveAsync<Blogs>(
                            query => query
                                .Published(true)
                                .OnSite(SiteContext.CurrentSiteName)
                                .TopN(9)
                                 .Columns(cols)
                                  .WhereNotEquals("NodeAliasPath", nodeAliasPath)
                                  .WhereContains("Tag", tag)
                                 .WhereEquals("IsActive", true)
                                .OrderByDescending("DocumentModifiedWhen")
                                .ToList(),
                            cache => cache
                                .Key($"{nameof(BlogRepository)}|{nameof(GetBlogsByTag)}|{tag}")
                                // Include path dependency to flush cache when a new child page is created or page order is changed.
                                .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                            new CancellationToken())?.Result.ToList();
                    }
                }

                if (blogs != null && blogs.Count > 0)
                {
                    foreach (var blog in blogs)
                    {
                        _blogs.Add(BlogListViewModel.GetModel(blog));
                    }
                }
                return _blogs;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "10000003", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Get latest top 3 blogs
        /// </summary>
        /// <returns></returns>
        private List<BlogListViewModel> GetRelatedBlogs(string category, string nodeAliasPath)
        {
            try
            {
                string[] cols = { "BlogsID", "Name", "BlogHeading", "ThumbnailImage", "ThumbnailImageAltText", "BlogAuthor", "BlogTopic", "BlogCreatedDate", "ShortTitle", "BlogTitle", "BlogContentText", "IsActive", "Category", "Tag", "NodeID", "NodeAliasPath", "DocumentModifiedWhen" };


                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");

                var blogs = new List<Blogs>();
                var _blogs = new List<BlogListViewModel>();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    blogs = pageRetriever.RetrieveAsync<Blogs>(
                        query => query

                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                            .TopN(3)
                             .Columns(cols)
                            //.Where(x => x.Category == category && x.IsActive == true && x.BlogsID != blogsID)
                            .WhereContains("Category", category)
                            .WhereEquals("IsActive", true)
                            .WhereNotEquals("NodeAliasPath", nodeAliasPath)
                            .OrderByDescending("DocumentModifiedWhen")
                            .ToList())?.Result.ToList();
                    //related = Enumerable.Cast<BannerSection>(data.Result);
                }
                else
                {
                    blogs = pageRetriever.RetrieveAsync<Blogs>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                            .TopN(3)
                             .Columns(cols)
                              .WhereContains("Category", category)
                            .WhereEquals("IsActive", true)
                            .WhereNotEquals("NodeAliasPath", nodeAliasPath)
                            .OrderByDescending("DocumentModifiedWhen")
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(BlogRepository)}|{nameof(GetRelatedBlogs)}|{category}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.ToList();
                }

                if (blogs != null && blogs.Count > 0)
                {
                    foreach (var blog in blogs)
                    {
                        _blogs.Add(BlogListViewModel.GetModel(blog));
                    }
                }
                return _blogs;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "10000002", ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private BlogControlsViewModel GetHeadings()
        {
            try
            {
                bool enableCache = SettingsKeyInfoProvider.GetBoolValue(SiteContext.CurrentSiteName + ".EnableCache");
                string[] cols = { "Name", "Heading", "SliderButtonID", "SliderButtonText", "ButtonID", "ButtonText", "ListingButtonID", "ListingButtonText" };
                var container = new BlogContainer();
                var _container = new BlogControlsViewModel();

                if (!enableCache)
                {
                    //IEnumerable<BannerSection> related = Enumerable.Empty<BannerSection>();
                    container = pageRetriever.RetrieveAsync<BlogContainer>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                            .TopN(1)
                            .FirstOrDefault())?.Result.FirstOrDefault();
                }
                else
                {
                    container = pageRetriever.RetrieveAsync<BlogContainer>(
                        query => query
                            .Published(true)
                            .OnSite(SiteContext.CurrentSiteName)
                             .Columns(cols)
                             .TopN(1)
                            .ToList(),
                        cache => cache
                            .Key($"{nameof(BlogRepository)}|{nameof(GetHeadings)}")
                            // Include path dependency to flush cache when a new child page is created or page order is changed.
                            .Dependencies((_, builder) => builder.PagePath("", PathTypeEnum.Children).PageOrder()),
                        new CancellationToken())?.Result.FirstOrDefault();

                }

                if (container != null)
                    _container = BlogControlsViewModel.GetControlHeading(container);

                return _container;
            }
            catch (System.Exception ex)
            {
                EventLogManager.LogError(ex.Source, "100000017", ex.Message);
                throw ex;
            }
        }

        #endregion

    }
}
