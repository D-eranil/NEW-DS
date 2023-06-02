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

[assembly: RegisterDocumentType(CareerCurrentOpening.CLASS_NAME, typeof(CareerCurrentOpening))]

namespace CMS.DocumentEngine.Types.DotStarK
{
	/// <summary>
	/// Represents a content item of type CareerCurrentOpening.
	/// </summary>
	public partial class CareerCurrentOpening : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DotStarK.CareerCurrentOpening";


		/// <summary>
		/// The instance of the class that provides extended API for working with CareerCurrentOpening fields.
		/// </summary>
		private readonly CareerCurrentOpeningFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// GeneralInformationSectionID.
		/// </summary>
		[DatabaseIDField]
		public int CareerCurrentOpeningID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("CareerCurrentOpeningID"), 0);
			}
			set
			{
				SetValue("CareerCurrentOpeningID", value);
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
		/// Gets an object that provides extended API for working with CareerCurrentOpening fields.
		/// </summary>
		[RegisterProperty]
		public CareerCurrentOpeningFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with CareerCurrentOpening fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class CareerCurrentOpeningFields : AbstractHierarchicalObject<CareerCurrentOpeningFields>
		{
			/// <summary>
			/// The content item of type CareerCurrentOpening that is a target of the extended API.
			/// </summary>
			private readonly CareerCurrentOpening mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="CareerCurrentOpeningFields" /> class with the specified content item of type CareerCurrentOpening.
			/// </summary>
			/// <param name="instance">The content item of type CareerCurrentOpening that is a target of the extended API.</param>
			public CareerCurrentOpeningFields(CareerCurrentOpening instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// GeneralInformationSectionID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.CareerCurrentOpeningID;
				}
				set
				{
					mInstance.CareerCurrentOpeningID = value;
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
		/// Initializes a new instance of the <see cref="CareerCurrentOpening" /> class.
		/// </summary>
		public CareerCurrentOpening() : base(CLASS_NAME)
		{
			mFields = new CareerCurrentOpeningFields(this);
		}

		#endregion
	}
}