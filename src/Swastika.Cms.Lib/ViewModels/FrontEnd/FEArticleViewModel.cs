﻿using System;
using System.Collections.Generic;
using Swastika.Cms.Lib.Models;
using Swastika.Domain.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Swastika.Common.Helper;
using Swastika.Cms.Lib;

namespace Swastika.Cms.Lib.ViewModels.FrontEnd
{
   
    public class FEArticleViewModel
        : ViewModelBase<SiocCmsContext, SiocArticle, FEArticleViewModel>
    {
        #region Properties

        #region Models
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("template")]
        public string Template { get; set; }
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("excerpt")]
        public string Excerpt { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("seoName")]
        public string SeoName { get; set; }
        [JsonProperty("seoTitle")]
        public string SeoTitle { get; set; }
        [JsonProperty("seoDescription")]
        public string SeoDescription { get; set; }
        [JsonProperty("seoKeywords")]
        public string SeoKeywords { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("views")]
        public int? Views { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }
        [JsonProperty("updatedDateTime")]
        public DateTime? UpdatedDateTime { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty("updatedBy")]
        public string UpdatedBy { get; set; }
        [JsonProperty("isVisible")]
        public bool IsVisible { get; set; }
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty("tags")]
        public string Tags { get; set; }
        #endregion

        #region Views
        [JsonProperty("modules")]
        public List<FEArticleModuleViewModel> Modules { get; set; }
        [JsonProperty("domain")]
        public string Domain { get; set; } = "/";
        [JsonProperty("imageUrl")]
        public string ImageUrl
        {
            get
            {
                if (Image != null && Image.IndexOf("http") == -1)
                {
                    return SWCmsHelper.GetFullPath(new string[] {
                    Domain,  Image
                });
                }
                else
                {
                    return Image;
                }

            }
        }
        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl
        {
            get
            {
                if (Thumbnail != null && Thumbnail.IndexOf("http") == -1)
                {
                    return SWCmsHelper.GetFullPath(new string[] {
                    Domain,  Thumbnail
                });
                }
                else
                {
                    return Thumbnail;
                }

            }
        }

        #endregion

        #endregion

        #region Contructors

        public FEArticleViewModel() : base()
        {
        }

        public FEArticleViewModel(SiocArticle model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null) : base(model, _context, _transaction)
        {
        }

        #endregion

        #region Overrides

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getModulesResult = FEArticleModuleViewModel.Repository.GetModelListBy(m => m.ArticleId == Id && m.Specificulture == Specificulture, _context, _transaction);
            if (getModulesResult.IsSucceed)
            {
                this.Modules = getModulesResult.Data;
            }
        }

        #endregion

        #region Expands
        void GenerateSEO()
        {
            if (string.IsNullOrEmpty(this.SeoName))
            {
                this.SeoName = SEOHelper.GetSEOString(this.Title);
            }

            if (string.IsNullOrEmpty(this.SeoTitle))
            {
                this.SeoTitle = SEOHelper.GetSEOString(this.Title);
            }

            if (string.IsNullOrEmpty(this.SeoDescription))
            {
                this.SeoDescription = SEOHelper.GetSEOString(this.Title);
            }

            if (string.IsNullOrEmpty(this.SeoKeywords))
            {
                this.SeoKeywords = SEOHelper.GetSEOString(this.Title);
            }
        }
        #endregion

    }
}
