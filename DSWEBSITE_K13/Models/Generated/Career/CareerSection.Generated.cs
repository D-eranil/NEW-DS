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

[assembly: RegisterDocumentType(CareerSection.CLASS_NAME, typeof(CareerSection))]

namespace CMS.DocumentEngine.Types.DotStarK
{
	/// <summary>
	/// Represents a content item of type CareerSection.
	/// </summary>
	public partial class CareerSection : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DotStarK.CareerSection";


		/// <summary>
		/// The instance of the class that provides extended API for working with CareerSection fields.
		/// </summary>
		private readonly CareerSectionFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// ServiceSectionID.
		/// </summary>
		[DatabaseIDField]
		public int CareerSectionID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("CareerSectionID"), 0);
			}
			set
			{
				SetValue("CareerSectionID", value);
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
		/// Service image.
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
		/// Image Location.
		/// </summary>
		[DatabaseField]
		public string ImageLocation
		{
			get
			{
				return ValidationHelper.GetString(GetValue("ImageLocation"), @"");
			}
			set
			{
				SetValue("ImageLocation", value);
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
		/// Gets an object that provides extended API for working with CareerSection fields.
		/// </summary>
		[RegisterProperty]
		public CareerSectionFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with CareerSection fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class CareerSectionFields : AbstractHierarchicalObject<CareerSectionFields>
		{
			/// <summary>
			/// The content item of type CareerSection that is a target of the extended API.
			/// </summary>
			private readonly CareerSection mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="CareerSectionFields" /> class with the specified content item of type CareerSection.
			/// </summary>
			/// <param name="instance">The content item of type CareerSection that is a target of the extended API.</param>
			public CareerSectionFields(CareerSection instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// ServiceSectionID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.CareerSectionID;
				}
				set
				{
					mInstance.CareerSectionID = value;
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
			/// Service image.
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
			/// Image Location.
			/// </summary>
			public string ImageLocation
			{
				get
				{
					return mInstance.ImageLocation;
				}
				set
				{
					mInstance.ImageLocation = value;
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
		/// Initializes a new instance of the <see cref="CareerSection" /> class.
		/// </summary>
		public CareerSection() : base(CLASS_NAME)
		{
			mFields = new CareerSectionFields(this);
		}

		#endregion
	}
}