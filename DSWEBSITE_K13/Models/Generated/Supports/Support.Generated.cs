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

[assembly: RegisterDocumentType(Support.CLASS_NAME, typeof(Support))]

namespace CMS.DocumentEngine.Types.DotStarK
{
	/// <summary>
	/// Represents a content item of type Support.
	/// </summary>
	public partial class Support : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DotStarK.Support";


		/// <summary>
		/// The instance of the class that provides extended API for working with Support fields.
		/// </summary>
		private readonly SupportFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// SupportID.
		/// </summary>
		[DatabaseIDField]
		public int SupportID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("SupportID"), 0);
			}
			set
			{
				SetValue("SupportID", value);
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
		/// Heading.
		/// </summary>
		[DatabaseField]
		public string Heading
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Heading"), @"");
			}
			set
			{
				SetValue("Heading", value);
			}
		}


		/// <summary>
		/// Content html.
		/// </summary>
		[DatabaseField]
		public string Content
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Content"), @"");
			}
			set
			{
				SetValue("Content", value);
			}
		}


		/// <summary>
		/// Icon/Image.
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
		/// Gets an object that provides extended API for working with Support fields.
		/// </summary>
		[RegisterProperty]
		public SupportFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Support fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class SupportFields : AbstractHierarchicalObject<SupportFields>
		{
			/// <summary>
			/// The content item of type Support that is a target of the extended API.
			/// </summary>
			private readonly Support mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="SupportFields" /> class with the specified content item of type Support.
			/// </summary>
			/// <param name="instance">The content item of type Support that is a target of the extended API.</param>
			public SupportFields(Support instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// SupportID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.SupportID;
				}
				set
				{
					mInstance.SupportID = value;
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
			/// Content html.
			/// </summary>
			public string Content
			{
				get
				{
					return mInstance.Content;
				}
				set
				{
					mInstance.Content = value;
				}
			}


			/// <summary>
			/// Icon/Image.
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
		/// Initializes a new instance of the <see cref="Support" /> class.
		/// </summary>
		public Support() : base(CLASS_NAME)
		{
			mFields = new SupportFields(this);
		}

		#endregion
	}
}