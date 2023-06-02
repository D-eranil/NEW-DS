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

[assembly: RegisterDocumentType(ClienteleContainer.CLASS_NAME, typeof(ClienteleContainer))]

namespace CMS.DocumentEngine.Types.DotStarK
{
	/// <summary>
	/// Represents a content item of type ClienteleContainer.
	/// </summary>
	public partial class ClienteleContainer : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DotStarK.ClienteleContainer";


		/// <summary>
		/// The instance of the class that provides extended API for working with ClienteleContainer fields.
		/// </summary>
		private readonly ClienteleContainerFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// ClienteleContainerID.
		/// </summary>
		[DatabaseIDField]
		public int ClienteleContainerID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("ClienteleContainerID"), 0);
			}
			set
			{
				SetValue("ClienteleContainerID", value);
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
				return ValidationHelper.GetString(GetValue("Heading"), @"Client Says");
			}
			set
			{
				SetValue("Heading", value);
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
		/// Gets an object that provides extended API for working with ClienteleContainer fields.
		/// </summary>
		[RegisterProperty]
		public ClienteleContainerFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with ClienteleContainer fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class ClienteleContainerFields : AbstractHierarchicalObject<ClienteleContainerFields>
		{
			/// <summary>
			/// The content item of type ClienteleContainer that is a target of the extended API.
			/// </summary>
			private readonly ClienteleContainer mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="ClienteleContainerFields" /> class with the specified content item of type ClienteleContainer.
			/// </summary>
			/// <param name="instance">The content item of type ClienteleContainer that is a target of the extended API.</param>
			public ClienteleContainerFields(ClienteleContainer instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// ClienteleContainerID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.ClienteleContainerID;
				}
				set
				{
					mInstance.ClienteleContainerID = value;
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
			/// Clienteles.
			/// </summary>
			public IEnumerable<TreeNode> Clienteles
			{
				get
				{
					return mInstance.GetRelatedDocuments("Clienteles");
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
		/// Initializes a new instance of the <see cref="ClienteleContainer" /> class.
		/// </summary>
		public ClienteleContainer() : base(CLASS_NAME)
		{
			mFields = new ClienteleContainerFields(this);
		}

		#endregion
	}
}