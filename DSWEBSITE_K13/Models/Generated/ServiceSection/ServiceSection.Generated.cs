//--------------------------------------------------------------------------------------------------
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

[assembly: RegisterDocumentType(ServiceSection.CLASS_NAME, typeof(ServiceSection))]

namespace CMS.DocumentEngine.Types.DotStarK
{
	/// <summary>
	/// Represents a content item of type ServiceSection.
	/// </summary>
	public partial class ServiceSection : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DotStarK.ServiceSection";


		/// <summary>
		/// The instance of the class that provides extended API for working with ServiceSection fields.
		/// </summary>
		private readonly ServiceSectionFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// ServiceSectionID.
		/// </summary>
		[DatabaseIDField]
		public int ServiceSectionID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("ServiceSectionID"), 0);
			}
			set
			{
				SetValue("ServiceSectionID", value);
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
		/// Gets an object that provides extended API for working with ServiceSection fields.
		/// </summary>
		[RegisterProperty]
		public ServiceSectionFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with ServiceSection fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class ServiceSectionFields : AbstractHierarchicalObject<ServiceSectionFields>
		{
			/// <summary>
			/// The content item of type ServiceSection that is a target of the extended API.
			/// </summary>
			private readonly ServiceSection mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="ServiceSectionFields" /> class with the specified content item of type ServiceSection.
			/// </summary>
			/// <param name="instance">The content item of type ServiceSection that is a target of the extended API.</param>
			public ServiceSectionFields(ServiceSection instance)
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
					return mInstance.ServiceSectionID;
				}
				set
				{
					mInstance.ServiceSectionID = value;
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
		/// Initializes a new instance of the <see cref="ServiceSection" /> class.
		/// </summary>
		public ServiceSection() : base(CLASS_NAME)
		{
			mFields = new ServiceSectionFields(this);
		}

		#endregion
	}
}