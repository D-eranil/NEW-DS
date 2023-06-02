﻿//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at https://docs.xperience.io/.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CMS;
using CMS.Base;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DotStarK;

[assembly: RegisterDocumentType(Technology.CLASS_NAME, typeof(Technology))]

namespace CMS.DocumentEngine.Types.DotStarK
{
	/// <summary>
	/// Represents a content item of type Technology.
	/// </summary>
	public partial class Technology : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DotStarK.Technology";


		/// <summary>
		/// The instance of the class that provides extended API for working with Technology fields.
		/// </summary>
		private readonly TechnologyFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// Technology_DSID.
		/// </summary>
		[DatabaseIDField]
		public int TechnologyID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("TechnologyID"), 0);
			}
			set
			{
				SetValue("TechnologyID", value);
			}
		}


		/// <summary>
		/// Name.
		/// </summary>
		[DatabaseField]
		public string Name
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Name"), @"");
			}
			set
			{
				SetValue("Name", value);
			}
		}


		/// <summary>
		/// Active.
		/// </summary>
		[DatabaseField]
		public bool IsActive
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("IsActive"), true);
			}
			set
			{
				SetValue("IsActive", value);
			}
		}


		/// <summary>
		/// Image.
		/// </summary>
		[DatabaseField]
		public string BannerImage
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BannerImage"), @"");
			}
			set
			{
				SetValue("BannerImage", value);
			}
		}


		/// <summary>
		/// Alternative text.
		/// </summary>
		[DatabaseField]
		public string ImageAltText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("ImageAltText"), @"");
			}
			set
			{
				SetValue("ImageAltText", value);
			}
		}


		/// <summary>
		/// Heading.
		/// </summary>
		[DatabaseField]
		public string Heading
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Heading"), @"Technology");
			}
			set
			{
				SetValue("Heading", value);
			}
		}


		/// <summary>
		/// SubHeading.
		/// </summary>
		[DatabaseField]
		public string SubHeading
		{
			get
			{
				return ValidationHelper.GetString(GetValue("SubHeading"), @"");
			}
			set
			{
				SetValue("SubHeading", value);
			}
		}


		/// <summary>
		/// Titile.
		/// </summary>
		[DatabaseField]
		public string Title
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Title"), @"DotStark Wireframe Kit");
			}
			set
			{
				SetValue("Title", value);
			}
		}


		/// <summary>
		/// Content.
		/// </summary>
		[DatabaseField]
		public string ContentText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("ContentText"), @"");
			}
			set
			{
				SetValue("ContentText", value);
			}
		}


		/// <summary>
		/// Is navigation breadcrumbs.
		/// </summary>
		[DatabaseField]
		public bool IsCategoryBreadcrumbs
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("IsCategoryBreadcrumbs"), false);
			}
			set
			{
				SetValue("IsCategoryBreadcrumbs", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Technology fields.
		/// </summary>
		[RegisterProperty]
		public TechnologyFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Technology fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class TechnologyFields : AbstractHierarchicalObject<TechnologyFields>
		{
			/// <summary>
			/// The content item of type Technology that is a target of the extended API.
			/// </summary>
			private readonly Technology mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="TechnologyFields" /> class with the specified content item of type Technology.
			/// </summary>
			/// <param name="instance">The content item of type Technology that is a target of the extended API.</param>
			public TechnologyFields(Technology instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// Technology_DSID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.TechnologyID;
				}
				set
				{
					mInstance.TechnologyID = value;
				}
			}


			/// <summary>
			/// Name.
			/// </summary>
			public string Name
			{
				get
				{
					return mInstance.Name;
				}
				set
				{
					mInstance.Name = value;
				}
			}


			/// <summary>
			/// Active.
			/// </summary>
			public bool IsActive
			{
				get
				{
					return mInstance.IsActive;
				}
				set
				{
					mInstance.IsActive = value;
				}
			}


			/// <summary>
			/// Image.
			/// </summary>
			public string BannerImage
			{
				get
				{
					return mInstance.BannerImage;
				}
				set
				{
					mInstance.BannerImage = value;
				}
			}


			/// <summary>
			/// Alternative text.
			/// </summary>
			public string ImageAltText
			{
				get
				{
					return mInstance.ImageAltText;
				}
				set
				{
					mInstance.ImageAltText = value;
				}
			}


			/// <summary>
			/// Heading.
			/// </summary>
			public string Heading
			{
				get
				{
					return mInstance.Heading;
				}
				set
				{
					mInstance.Heading = value;
				}
			}


			/// <summary>
			/// SubHeading.
			/// </summary>
			public string SubHeading
			{
				get
				{
					return mInstance.SubHeading;
				}
				set
				{
					mInstance.SubHeading = value;
				}
			}


			/// <summary>
			/// Titile.
			/// </summary>
			public string Title
			{
				get
				{
					return mInstance.Title;
				}
				set
				{
					mInstance.Title = value;
				}
			}


			/// <summary>
			/// Content.
			/// </summary>
			public string ContentText
			{
				get
				{
					return mInstance.ContentText;
				}
				set
				{
					mInstance.ContentText = value;
				}
			}


			/// <summary>
			/// Is navigation breadcrumbs.
			/// </summary>
			public bool IsCategoryBreadcrumbs
			{
				get
				{
					return mInstance.IsCategoryBreadcrumbs;
				}
				set
				{
					mInstance.IsCategoryBreadcrumbs = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Technology" /> class.
		/// </summary>
		public Technology() : base(CLASS_NAME)
		{
			mFields = new TechnologyFields(this);
		}

		#endregion
	}
}