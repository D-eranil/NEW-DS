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

[assembly: RegisterDocumentType(Branches.CLASS_NAME, typeof(Branches))]

namespace CMS.DocumentEngine.Types.DotStarK
{
	/// <summary>
	/// Represents a content item of type Branches.
	/// </summary>
	public partial class Branches : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DotStarK.Branches";


		/// <summary>
		/// The instance of the class that provides extended API for working with Branches fields.
		/// </summary>
		private readonly BranchesFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// BranchesID.
		/// </summary>
		[DatabaseIDField]
		public int BranchesID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("BranchesID"), 0);
			}
			set
			{
				SetValue("BranchesID", value);
			}
		}


		/// <summary>
		/// Branch name.
		/// </summary>
		[DatabaseField]
		public string BranchName
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BranchName"), @"");
			}
			set
			{
				SetValue("BranchName", value);
			}
		}


		/// <summary>
		///  Branch address.
		/// </summary>
		[DatabaseField]
		public string BranchAddress
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BranchAddress"), @"");
			}
			set
			{
				SetValue("BranchAddress", value);
			}
		}


		/// <summary>
		/// Branch image.
		/// </summary>
		[DatabaseField]
		public string BranchImage
		{
			get
			{
				return ValidationHelper.GetString(GetValue("BranchImage"), @"");
			}
			set
			{
				SetValue("BranchImage", value);
			}
		}


		/// <summary>
		/// Image alt text.
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
		/// Is active.
		/// </summary>
		[DatabaseField]
		public bool IsActive
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("IsActive"), false);
			}
			set
			{
				SetValue("IsActive", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with Branches fields.
		/// </summary>
		[RegisterProperty]
		public BranchesFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Branches fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class BranchesFields : AbstractHierarchicalObject<BranchesFields>
		{
			/// <summary>
			/// The content item of type Branches that is a target of the extended API.
			/// </summary>
			private readonly Branches mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="BranchesFields" /> class with the specified content item of type Branches.
			/// </summary>
			/// <param name="instance">The content item of type Branches that is a target of the extended API.</param>
			public BranchesFields(Branches instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// BranchesID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.BranchesID;
				}
				set
				{
					mInstance.BranchesID = value;
				}
			}


			/// <summary>
			/// Branch name.
			/// </summary>
			public string BranchName
			{
				get
				{
					return mInstance.BranchName;
				}
				set
				{
					mInstance.BranchName = value;
				}
			}


			/// <summary>
			///  Branch address.
			/// </summary>
			public string BranchAddress
			{
				get
				{
					return mInstance.BranchAddress;
				}
				set
				{
					mInstance.BranchAddress = value;
				}
			}


			/// <summary>
			/// Branch image.
			/// </summary>
			public string BranchImage
			{
				get
				{
					return mInstance.BranchImage;
				}
				set
				{
					mInstance.BranchImage = value;
				}
			}


			/// <summary>
			/// Image alt text.
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
			/// Is active.
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
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="Branches" /> class.
		/// </summary>
		public Branches() : base(CLASS_NAME)
		{
			mFields = new BranchesFields(this);
		}

		#endregion
	}
}