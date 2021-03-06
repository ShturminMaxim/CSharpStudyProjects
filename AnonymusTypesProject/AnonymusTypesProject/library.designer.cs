﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.0
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnonymusTypesProject
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="library")]
	public partial class libraryDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertBooks(Books instance);
    partial void UpdateBooks(Books instance);
    partial void DeleteBooks(Books instance);
    #endregion
		
		public libraryDataContext() : 
				base(global::AnonymusTypesProject.Properties.Settings.Default.libraryConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public libraryDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public libraryDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public libraryDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public libraryDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Books> Books
		{
			get
			{
				return this.GetTable<Books>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Books")]
	public partial class Books : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private int _Pages;
		
		private int _YearPress;
		
		private int _Id_Themes;
		
		private int _Id_Category;
		
		private int _Id_Author;
		
		private int _Id_Press;
		
		private string _Comment;
		
		private int _Quantity;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPagesChanging(int value);
    partial void OnPagesChanged();
    partial void OnYearPressChanging(int value);
    partial void OnYearPressChanged();
    partial void OnId_ThemesChanging(int value);
    partial void OnId_ThemesChanged();
    partial void OnId_CategoryChanging(int value);
    partial void OnId_CategoryChanged();
    partial void OnId_AuthorChanging(int value);
    partial void OnId_AuthorChanged();
    partial void OnId_PressChanging(int value);
    partial void OnId_PressChanged();
    partial void OnCommentChanging(string value);
    partial void OnCommentChanged();
    partial void OnQuantityChanging(int value);
    partial void OnQuantityChanged();
    #endregion
		
		public Books()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pages", DbType="Int NOT NULL")]
		public int Pages
		{
			get
			{
				return this._Pages;
			}
			set
			{
				if ((this._Pages != value))
				{
					this.OnPagesChanging(value);
					this.SendPropertyChanging();
					this._Pages = value;
					this.SendPropertyChanged("Pages");
					this.OnPagesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YearPress", DbType="Int NOT NULL")]
		public int YearPress
		{
			get
			{
				return this._YearPress;
			}
			set
			{
				if ((this._YearPress != value))
				{
					this.OnYearPressChanging(value);
					this.SendPropertyChanging();
					this._YearPress = value;
					this.SendPropertyChanged("YearPress");
					this.OnYearPressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Themes", DbType="Int NOT NULL")]
		public int Id_Themes
		{
			get
			{
				return this._Id_Themes;
			}
			set
			{
				if ((this._Id_Themes != value))
				{
					this.OnId_ThemesChanging(value);
					this.SendPropertyChanging();
					this._Id_Themes = value;
					this.SendPropertyChanged("Id_Themes");
					this.OnId_ThemesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Category", DbType="Int NOT NULL")]
		public int Id_Category
		{
			get
			{
				return this._Id_Category;
			}
			set
			{
				if ((this._Id_Category != value))
				{
					this.OnId_CategoryChanging(value);
					this.SendPropertyChanging();
					this._Id_Category = value;
					this.SendPropertyChanged("Id_Category");
					this.OnId_CategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Author", DbType="Int NOT NULL")]
		public int Id_Author
		{
			get
			{
				return this._Id_Author;
			}
			set
			{
				if ((this._Id_Author != value))
				{
					this.OnId_AuthorChanging(value);
					this.SendPropertyChanging();
					this._Id_Author = value;
					this.SendPropertyChanged("Id_Author");
					this.OnId_AuthorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Press", DbType="Int NOT NULL")]
		public int Id_Press
		{
			get
			{
				return this._Id_Press;
			}
			set
			{
				if ((this._Id_Press != value))
				{
					this.OnId_PressChanging(value);
					this.SendPropertyChanging();
					this._Id_Press = value;
					this.SendPropertyChanged("Id_Press");
					this.OnId_PressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Comment", DbType="VarChar(50)")]
		public string Comment
		{
			get
			{
				return this._Comment;
			}
			set
			{
				if ((this._Comment != value))
				{
					this.OnCommentChanging(value);
					this.SendPropertyChanging();
					this._Comment = value;
					this.SendPropertyChanged("Comment");
					this.OnCommentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
