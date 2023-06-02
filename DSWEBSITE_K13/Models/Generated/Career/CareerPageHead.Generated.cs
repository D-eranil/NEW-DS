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

[assembly: RegisterDocumentType(CareerPageHead.CLASS_NAME, typeof(CareerPageHead))]

namespace CMS.DocumentEngine.Types.DotStarK
{
	/// <summary>
	/// Represents a content item of type CareerPageHead.
	/// </summary>
	public partial class CareerPageHead : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DotStarK.CareerPageHead";


		/// <summary>
		/// The instance of the class that provides extended API for working with CareerPageHead fields.
		/// </summary>
		private readonly CareerPageHeadFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// InnerPageHeadID.
		/// </summary>
		[DatabaseIDField]
		public int CareerPageHeadID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("CareerPageHeadID"), 0);
			}
			set
			{
				SetValue("CareerPageHeadID", value);
			}
		}


		/// <summary>
		/// Banner title.
		/// </summary>
		[DatabaseField]
		public string BannerTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BannerTitle"), @"");
			}
			set
			{
				SetValue("BannerTitle", value);
			}
		}


		/// <summary>
		/// Sub title.
		/// </summary>
		[DatabaseField]
		public string SubTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("SubTitle"), @"");
			}
			set
			{
				SetValue("SubTitle", value);
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
		/// Banner image.
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
		/// Is Form Enabled.
		/// </summary>
		[DatabaseField]
		public bool FormEnabled
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("FormEnabled"), true);
			}
			set
			{
				SetValue("FormEnabled", value);
			}
		}


		/// <summary>
		/// Title.
		/// </summary>
		[DatabaseField]
		public string FormTitle
		{
			get
			{
				return ValidationHelper.GetString(GetValue("FormTitle"), @"");
			}
			set
			{
				SetValue("FormTitle", value);
			}
		}


		/// <summary>
		/// Short Description.
		/// </summary>
		[DatabaseField]
		public string ShortDescription
		{
			get
			{
				return ValidationHelper.GetString(GetValue("ShortDescription"), @"");
			}
			set
			{
				SetValue("ShortDescription", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with CareerPageHead fields.
		/// </summary>
		[RegisterProperty]
		public CareerPageHeadFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with CareerPageHead fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class CareerPageHeadFields : AbstractHierarchicalObject<CareerPageHeadFields>
		{
			/// <summary>
			/// The content item of type CareerPageHead that is a target of the extended API.
			/// </summary>
			private readonly CareerPageHead mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="CareerPageHeadFields" /> class with the specified content item of type CareerPageHead.
			/// </summary>
			/// <param name="instance">The content item of type CareerPageHead that is a target of the extended API.</param>
			public CareerPageHeadFields(CareerPageHead instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// InnerPageHeadID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.CareerPageHeadID;
				}
				set
				{
					mInstance.CareerPageHeadID = value;
				}
			}


			/// <summary>
			/// Banner title.
			/// </summary>
			public string BannerTitle
			{
				get
				{
					return mInstance.BannerTitle;
				}
				set
				{
					mInstance.BannerTitle = value;
				}
			}


			/// <summary>
			/// Sub title.
			/// </summary>
			public string SubTitle
			{
				get
				{
					return mInstance.SubTitle;
				}
				set
				{
					mInstance.SubTitle = value;
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
			/// Banner image.
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
			/// Is Form Enabled.
			/// </summary>
			public bool FormEnabled
			{
				get
				{
					return mInstance.FormEnabled;
				}
				set
				{
					mInstance.FormEnabled = value;
				}
			}


			/// <summary>
			/// Title.
			/// </summary>
			public string FormTitle
			{
				get
				{
					return mInstance.FormTitle;
				}
				set
				{
					mInstance.FormTitle = value;
				}
			}


			/// <summary>
			/// Short Description.
			/// </summary>
			public string ShortDescription
			{
				get
				{
					return mInstance.ShortDescription;
				}
				set
				{
					mInstance.ShortDescription = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="CareerPageHead" /> class.
		/// </summary>
		public CareerPageHead() : base(CLASS_NAME)
		{
			mFields = new CareerPageHeadFields(this);
		}

		#endregion
	}
}