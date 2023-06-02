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

[assembly: RegisterDocumentType(CareerSectionOpening.CLASS_NAME, typeof(CareerSectionOpening))]

namespace CMS.DocumentEngine.Types.DotStarK
{
	/// <summary>
	/// Represents a content item of type CareerSectionOpening.
	/// </summary>
	public partial class CareerSectionOpening : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DotStarK.CareerSectionOpening";


		/// <summary>
		/// The instance of the class that provides extended API for working with CareerSectionOpening fields.
		/// </summary>
		private readonly CareerSectionOpeningFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// CareerSectionOpeningID.
		/// </summary>
		[DatabaseIDField]
		public int CareerSectionOpeningID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("CareerSectionOpeningID"), 0);
			}
			set
			{
				SetValue("CareerSectionOpeningID", value);
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
				return ValidationHelper.GetString(GetValue("Heading"), @"Current Openings");
			}
			set
			{
				SetValue("Heading", value);
			}
		}


		/// <summary>
		/// Heading Sub Text.
		/// </summary>
		[DatabaseField]
		public string HeadingContent
		{
			get
			{
				return ValidationHelper.GetString(GetValue("HeadingContent"), @"");
			}
			set
			{
				SetValue("HeadingContent", value);
			}
		}


		/// <summary>
		/// Bullet points.
		/// </summary>
		[DatabaseField]
		public string BulletPoint
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BulletPoint"), @"");
			}
			set
			{
				SetValue("BulletPoint", value);
			}
		}


		/// <summary>
		/// Show in header.
		/// </summary>
		[DatabaseField]
		public bool ShowInHeader
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("ShowInHeader"), false);
			}
			set
			{
				SetValue("ShowInHeader", value);
			}
		}


		/// <summary>
		/// Show in footer.
		/// </summary>
		[DatabaseField]
		public bool ShowInFooter
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("ShowInFooter"), false);
			}
			set
			{
				SetValue("ShowInFooter", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with CareerSectionOpening fields.
		/// </summary>
		[RegisterProperty]
		public CareerSectionOpeningFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with CareerSectionOpening fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class CareerSectionOpeningFields : AbstractHierarchicalObject<CareerSectionOpeningFields>
		{
			/// <summary>
			/// The content item of type CareerSectionOpening that is a target of the extended API.
			/// </summary>
			private readonly CareerSectionOpening mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="CareerSectionOpeningFields" /> class with the specified content item of type CareerSectionOpening.
			/// </summary>
			/// <param name="instance">The content item of type CareerSectionOpening that is a target of the extended API.</param>
			public CareerSectionOpeningFields(CareerSectionOpening instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// CareerSectionOpeningID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.CareerSectionOpeningID;
				}
				set
				{
					mInstance.CareerSectionOpeningID = value;
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
			/// Heading Sub Text.
			/// </summary>
			public string HeadingContent
			{
				get
				{
					return mInstance.HeadingContent;
				}
				set
				{
					mInstance.HeadingContent = value;
				}
			}


			/// <summary>
			/// Bullet points.
			/// </summary>
			public string BulletPoint
			{
				get
				{
					return mInstance.BulletPoint;
				}
				set
				{
					mInstance.BulletPoint = value;
				}
			}


			/// <summary>
			/// Show in header.
			/// </summary>
			public bool ShowInHeader
			{
				get
				{
					return mInstance.ShowInHeader;
				}
				set
				{
					mInstance.ShowInHeader = value;
				}
			}


			/// <summary>
			/// Show in footer.
			/// </summary>
			public bool ShowInFooter
			{
				get
				{
					return mInstance.ShowInFooter;
				}
				set
				{
					mInstance.ShowInFooter = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="CareerSectionOpening" /> class.
		/// </summary>
		public CareerSectionOpening() : base(CLASS_NAME)
		{
			mFields = new CareerSectionOpeningFields(this);
		}

		#endregion
	}
}