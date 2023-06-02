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

[assembly: RegisterDocumentType(Pages.CLASS_NAME, typeof(Pages))]

namespace CMS.DocumentEngine.Types.DotStarK
{
	/// <summary>
	/// Represents a content item of type Pages.
	/// </summary>
	public partial class Pages : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DotStarK.Pages";


		/// <summary>
		/// The instance of the class that provides extended API for working with Pages fields.
		/// </summary>
		private readonly PagesFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// PagesID.
		/// </summary>
		[DatabaseIDField]
		public int PagesID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("PagesID"), 0);
			}
			set
			{
				SetValue("PagesID", value);
			}
		}


		/// <summary>
		/// Page name.
		/// </summary>
		[DatabaseField]
		public string PageName
		{
			get
			{
				return ValidationHelper.GetString(GetValue("PageName"), @"");
			}
			set
			{
				SetValue("PageName", value);
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
		/// Gets an object that provides extended API for working with Pages fields.
		/// </summary>
		[RegisterProperty]
		public PagesFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with Pages fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class PagesFields : AbstractHierarchicalObject<PagesFields>
		{
			/// <summary>
			/// The content item of type Pages that is a target of the extended API.
			/// </summary>
			private readonly Pages mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="PagesFields" /> class with the specified content item of type Pages.
			/// </summary>
			/// <param name="instance">The content item of type Pages that is a target of the extended API.</param>
			public PagesFields(Pages instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// PagesID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.PagesID;
				}
				set
				{
					mInstance.PagesID = value;
				}
			}


			/// <summary>
			/// Page name.
			/// </summary>
			public string PageName
			{
				get
				{
					return mInstance.PageName;
				}
				set
				{
					mInstance.PageName = value;
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
		/// Initializes a new instance of the <see cref="Pages" /> class.
		/// </summary>
		public Pages() : base(CLASS_NAME)
		{
			mFields = new PagesFields(this);
		}

		#endregion
	}
}