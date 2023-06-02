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

[assembly: RegisterDocumentType(InnerPageSection.CLASS_NAME, typeof(InnerPageSection))]

namespace CMS.DocumentEngine.Types.DotStarK
{
	/// <summary>
	/// Represents a content item of type InnerPageSection.
	/// </summary>
	public partial class InnerPageSection : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DotStarK.InnerPageSection";


		/// <summary>
		/// The instance of the class that provides extended API for working with InnerPageSection fields.
		/// </summary>
		private readonly InnerPageSectionFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// IndustrySectionID.
		/// </summary>
		[DatabaseIDField]
		public int InnerPageSectionID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("InnerPageSectionID"), 0);
			}
			set
			{
				SetValue("InnerPageSectionID", value);
			}
		}


		/// <summary>
		/// Title.
		/// </summary>
		[DatabaseField]
		public string Title
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Title"), @"");
			}
			set
			{
				SetValue("Title", value);
			}
		}


		/// <summary>
		/// Description.
		/// </summary>
		[DatabaseField]
		public string Description
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Description"), @"");
			}
			set
			{
				SetValue("Description", value);
			}
		}


		/// <summary>
		/// Is H3 section.
		/// </summary>
		[DatabaseField]
		public bool IsH3Section
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("IsH3Section"), false);
			}
			set
			{
				SetValue("IsH3Section", value);
			}
		}


		/// <summary>
		/// Background image.
		/// </summary>
		[DatabaseField]
		public string Image
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Image"), @"");
			}
			set
			{
				SetValue("Image", value);
			}
		}


		/// <summary>
		/// Themes color.
		/// </summary>
		[DatabaseField]
		public string ThemesColor
		{
			get
			{
				return ValidationHelper.GetString(GetValue("ThemesColor"), @"");
			}
			set
			{
				SetValue("ThemesColor", value);
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
		/// Gets an object that provides extended API for working with InnerPageSection fields.
		/// </summary>
		[RegisterProperty]
		public InnerPageSectionFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with InnerPageSection fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class InnerPageSectionFields : AbstractHierarchicalObject<InnerPageSectionFields>
		{
			/// <summary>
			/// The content item of type InnerPageSection that is a target of the extended API.
			/// </summary>
			private readonly InnerPageSection mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="InnerPageSectionFields" /> class with the specified content item of type InnerPageSection.
			/// </summary>
			/// <param name="instance">The content item of type InnerPageSection that is a target of the extended API.</param>
			public InnerPageSectionFields(InnerPageSection instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// IndustrySectionID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.InnerPageSectionID;
				}
				set
				{
					mInstance.InnerPageSectionID = value;
				}
			}


			/// <summary>
			/// Title.
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
			/// Description.
			/// </summary>
			public string Description
			{
				get
				{
					return mInstance.Description;
				}
				set
				{
					mInstance.Description = value;
				}
			}


			/// <summary>
			/// Is H3 section.
			/// </summary>
			public bool IsH3Section
			{
				get
				{
					return mInstance.IsH3Section;
				}
				set
				{
					mInstance.IsH3Section = value;
				}
			}


			/// <summary>
			/// Background image.
			/// </summary>
			public string Image
			{
				get
				{
					return mInstance.Image;
				}
				set
				{
					mInstance.Image = value;
				}
			}


			/// <summary>
			/// Themes color.
			/// </summary>
			public string ThemesColor
			{
				get
				{
					return mInstance.ThemesColor;
				}
				set
				{
					mInstance.ThemesColor = value;
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
		/// Initializes a new instance of the <see cref="InnerPageSection" /> class.
		/// </summary>
		public InnerPageSection() : base(CLASS_NAME)
		{
			mFields = new InnerPageSectionFields(this);
		}

		#endregion
	}
}