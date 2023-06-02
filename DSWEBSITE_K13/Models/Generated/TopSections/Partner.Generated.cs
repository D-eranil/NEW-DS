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

[assembly: RegisterDocumentType(Partners.CLASS_NAME, typeof(Partners))]

namespace CMS.DocumentEngine.Types.DotStarK
{
	/// <summary>
	/// Represents a content item of type Partners.
	/// </summary>
	public partial class Partners : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DotStarK.Partners";


		/// <summary>
		/// The instance of the class that provides extended API for working with Partners fields.
		/// </summary>
		private readonly PartnersFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// PartnersID.
		/// </summary>
		[DatabaseIDField]
		public int PartnersID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("PartnersID"), 0);
			}
			set
			{
				SetValue("PartnersID", value);
			}
		}


		/// <summary>
		/// Partner image URL.
		/// </summary>
		[DatabaseField]
		public string PartnerImageURL
		{
			get
			{
				return ValidationHelper.GetString(GetValue("PartnerImageURL"), @"");
			}
			set
			{
				SetValue("PartnerImageURL", value);
			}
		}


		/// <summary>
		/// Alternative text.
		/// </summary>
		[DatabaseField]
		public string PartnerImageAltText
		{
			get
			{
				return ValidationHelper.GetString(GetValue("PartnerImageAltText"), @"");
			}
			set
			{
				SetValue("PartnerImageAltText", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Partners fields.
		/// </summary>
		[RegisterProperty]
		public PartnersFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Partners fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class PartnersFields : AbstractHierarchicalObject<PartnersFields>
		{
			/// <summary>
			/// The content item of type Partners that is a target of the extended API.
			/// </summary>
			private readonly Partners mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="PartnersFields" /> class with the specified content item of type Partners.
			/// </summary>
			/// <param name="instance">The content item of type Partners that is a target of the extended API.</param>
			public PartnersFields(Partners instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// PartnersID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.PartnersID;
				}
				set
				{
					mInstance.PartnersID = value;
				}
			}


			/// <summary>
			/// Partner image URL.
			/// </summary>
			public string PartnerImageURL
			{
				get
				{
					return mInstance.PartnerImageURL;
				}
				set
				{
					mInstance.PartnerImageURL = value;
				}
			}


			/// <summary>
			/// Alternative text.
			/// </summary>
			public string PartnerImageAltText
			{
				get
				{
					return mInstance.PartnerImageAltText;
				}
				set
				{
					mInstance.PartnerImageAltText = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Partners" /> class.
		/// </summary>
		public Partners() : base(CLASS_NAME)
		{
			mFields = new PartnersFields(this);
		}

		#endregion
	}
}