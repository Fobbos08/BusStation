﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18444
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bus.Bussines.LINQtoSQL
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
	
	
	public partial class BusBaseDataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertStation(Station instance);
    partial void UpdateStation(Station instance);
    partial void DeleteStation(Station instance);
    partial void InsertBus(Bus instance);
    partial void UpdateBus(Bus instance);
    partial void DeleteBus(Bus instance);
    partial void InsertBusPath(BusPath instance);
    partial void UpdateBusPath(BusPath instance);
    partial void DeleteBusPath(BusPath instance);
    partial void InsertTime(Time instance);
    partial void UpdateTime(Time instance);
    partial void DeleteTime(Time instance);
    partial void InsertBusPathToTime(BusPathToTime instance);
    partial void UpdateBusPathToTime(BusPathToTime instance);
    partial void DeleteBusPathToTime(BusPathToTime instance);
    #endregion
		
		public BusBaseDataDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["MyNewBusStationConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public BusBaseDataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BusBaseDataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BusBaseDataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BusBaseDataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Station> Stations
		{
			get
			{
				return this.GetTable<Station>();
			}
		}
		
		public System.Data.Linq.Table<Bus> Bus
		{
			get
			{
				return this.GetTable<Bus>();
			}
		}
		
		public System.Data.Linq.Table<BusPath> BusPaths
		{
			get
			{
				return this.GetTable<BusPath>();
			}
		}
		
		public System.Data.Linq.Table<Time> Times
		{
			get
			{
				return this.GetTable<Time>();
			}
		}
		
		public System.Data.Linq.Table<BusPathToTime> BusPathToTimes
		{
			get
			{
				return this.GetTable<BusPathToTime>();
			}
		}
		
		public System.Data.Linq.Table<Users> Users
		{
			get
			{
				return this.GetTable<Users>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Station : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private string _Position;
		
		private EntitySet<BusPath> _BusPaths;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPositionChanging(string value);
    partial void OnPositionChanged();
    #endregion
		
		public Station()
		{
			this._BusPaths = new EntitySet<BusPath>(new Action<BusPath>(this.attach_BusPaths), new Action<BusPath>(this.detach_BusPaths));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Position", CanBeNull=false)]
		public string Position
		{
			get
			{
				return this._Position;
			}
			set
			{
				if ((this._Position != value))
				{
					this.OnPositionChanging(value);
					this.SendPropertyChanging();
					this._Position = value;
					this.SendPropertyChanged("Position");
					this.OnPositionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Station_BusPath", Storage="_BusPaths", ThisKey="ID", OtherKey="Station_ID")]
		public EntitySet<BusPath> BusPaths
		{
			get
			{
				return this._BusPaths;
			}
			set
			{
				this._BusPaths.Assign(value);
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
		
		private void attach_BusPaths(BusPath entity)
		{
			this.SendPropertyChanging();
			entity.Station = this;
		}
		
		private void detach_BusPaths(BusPath entity)
		{
			this.SendPropertyChanging();
			entity.Station = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Bus : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Code;
		
		private string _Name;
		
		private EntitySet<BusPath> _BusPaths;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnCodeChanging(string value);
    partial void OnCodeChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Bus()
		{
			this._BusPaths = new EntitySet<BusPath>(new Action<BusPath>(this.attach_BusPaths), new Action<BusPath>(this.detach_BusPaths));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", CanBeNull=false)]
		public string Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this.OnCodeChanging(value);
					this.SendPropertyChanging();
					this._Code = value;
					this.SendPropertyChanged("Code");
					this.OnCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Bus_BusPath", Storage="_BusPaths", ThisKey="ID", OtherKey="Bus_ID")]
		public EntitySet<BusPath> BusPaths
		{
			get
			{
				return this._BusPaths;
			}
			set
			{
				this._BusPaths.Assign(value);
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
		
		private void attach_BusPaths(BusPath entity)
		{
			this.SendPropertyChanging();
			entity.Bus = this;
		}
		
		private void detach_BusPaths(BusPath entity)
		{
			this.SendPropertyChanging();
			entity.Bus = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class BusPath : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _Station_ID;
		
		private int _Bus_ID;
		
		private string _StationNumber;
		
		private EntitySet<BusPathToTime> _BusPathToTimes;
		
		private EntityRef<Station> _Station;
		
		private EntityRef<Bus> _Bus;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnStation_IDChanging(int value);
    partial void OnStation_IDChanged();
    partial void OnBus_IDChanging(int value);
    partial void OnBus_IDChanged();
    partial void OnStationNumberChanging(string value);
    partial void OnStationNumberChanged();
    #endregion
		
		public BusPath()
		{
			this._BusPathToTimes = new EntitySet<BusPathToTime>(new Action<BusPathToTime>(this.attach_BusPathToTimes), new Action<BusPathToTime>(this.detach_BusPathToTimes));
			this._Station = default(EntityRef<Station>);
			this._Bus = default(EntityRef<Bus>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Station_ID")]
		public int Station_ID
		{
			get
			{
				return this._Station_ID;
			}
			set
			{
				if ((this._Station_ID != value))
				{
					if (this._Station.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnStation_IDChanging(value);
					this.SendPropertyChanging();
					this._Station_ID = value;
					this.SendPropertyChanged("Station_ID");
					this.OnStation_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bus_ID")]
		public int Bus_ID
		{
			get
			{
				return this._Bus_ID;
			}
			set
			{
				if ((this._Bus_ID != value))
				{
					if (this._Bus.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBus_IDChanging(value);
					this.SendPropertyChanging();
					this._Bus_ID = value;
					this.SendPropertyChanged("Bus_ID");
					this.OnBus_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StationNumber", CanBeNull=false)]
		public string StationNumber
		{
			get
			{
				return this._StationNumber;
			}
			set
			{
				if ((this._StationNumber != value))
				{
					this.OnStationNumberChanging(value);
					this.SendPropertyChanging();
					this._StationNumber = value;
					this.SendPropertyChanged("StationNumber");
					this.OnStationNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BusPath_BusPathToTime", Storage="_BusPathToTimes", ThisKey="ID", OtherKey="BusPath_ID")]
		public EntitySet<BusPathToTime> BusPathToTimes
		{
			get
			{
				return this._BusPathToTimes;
			}
			set
			{
				this._BusPathToTimes.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Station_BusPath", Storage="_Station", ThisKey="Station_ID", OtherKey="ID", IsForeignKey=true)]
		public Station Station
		{
			get
			{
				return this._Station.Entity;
			}
			set
			{
				Station previousValue = this._Station.Entity;
				if (((previousValue != value) 
							|| (this._Station.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Station.Entity = null;
						previousValue.BusPaths.Remove(this);
					}
					this._Station.Entity = value;
					if ((value != null))
					{
						value.BusPaths.Add(this);
						this._Station_ID = value.ID;
					}
					else
					{
						this._Station_ID = default(int);
					}
					this.SendPropertyChanged("Station");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Bus_BusPath", Storage="_Bus", ThisKey="Bus_ID", OtherKey="ID", IsForeignKey=true)]
		public Bus Bus
		{
			get
			{
				return this._Bus.Entity;
			}
			set
			{
				Bus previousValue = this._Bus.Entity;
				if (((previousValue != value) 
							|| (this._Bus.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Bus.Entity = null;
						previousValue.BusPaths.Remove(this);
					}
					this._Bus.Entity = value;
					if ((value != null))
					{
						value.BusPaths.Add(this);
						this._Bus_ID = value.ID;
					}
					else
					{
						this._Bus_ID = default(int);
					}
					this.SendPropertyChanged("Bus");
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
		
		private void attach_BusPathToTimes(BusPathToTime entity)
		{
			this.SendPropertyChanging();
			entity.BusPath = this;
		}
		
		private void detach_BusPathToTimes(BusPathToTime entity)
		{
			this.SendPropertyChanging();
			entity.BusPath = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Time : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Hour;
		
		private string _Minute;
		
		private string _FreeDay;
		
		private EntitySet<BusPathToTime> _BusPathToTimes;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnHourChanging(string value);
    partial void OnHourChanged();
    partial void OnMinuteChanging(string value);
    partial void OnMinuteChanged();
    partial void OnTypeDayChanging(string value);
    partial void OnTypeDayChanged();
    #endregion
		
		public Time()
		{
			this._BusPathToTimes = new EntitySet<BusPathToTime>(new Action<BusPathToTime>(this.attach_BusPathToTimes), new Action<BusPathToTime>(this.detach_BusPathToTimes));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hour", CanBeNull=false)]
		public string Hour
		{
			get
			{
				return this._Hour;
			}
			set
			{
				if ((this._Hour != value))
				{
					this.OnHourChanging(value);
					this.SendPropertyChanging();
					this._Hour = value;
					this.SendPropertyChanged("Hour");
					this.OnHourChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Minute", CanBeNull=false)]
		public string Minute
		{
			get
			{
				return this._Minute;
			}
			set
			{
				if ((this._Minute != value))
				{
					this.OnMinuteChanging(value);
					this.SendPropertyChanging();
					this._Minute = value;
					this.SendPropertyChanged("Minute");
					this.OnMinuteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="FreeDay", Storage="_FreeDay", CanBeNull=false)]
		public string TypeDay
		{
			get
			{
				return this._FreeDay;
			}
			set
			{
				if ((this._FreeDay != value))
				{
					this.OnTypeDayChanging(value);
					this.SendPropertyChanging();
					this._FreeDay = value;
					this.SendPropertyChanged("TypeDay");
					this.OnTypeDayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Time_BusPathToTime", Storage="_BusPathToTimes", ThisKey="ID", OtherKey="Time_ID")]
		public EntitySet<BusPathToTime> BusPathToTimes
		{
			get
			{
				return this._BusPathToTimes;
			}
			set
			{
				this._BusPathToTimes.Assign(value);
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
		
		private void attach_BusPathToTimes(BusPathToTime entity)
		{
			this.SendPropertyChanging();
			entity.Time = this;
		}
		
		private void detach_BusPathToTimes(BusPathToTime entity)
		{
			this.SendPropertyChanging();
			entity.Time = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class BusPathToTime : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BusPath_ID;
		
		private int _Time_ID;
		
		private int _ID;
		
		private EntityRef<BusPath> _BusPath;
		
		private EntityRef<Time> _Time;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBusPath_IDChanging(int value);
    partial void OnBusPath_IDChanged();
    partial void OnTime_IDChanging(int value);
    partial void OnTime_IDChanged();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    #endregion
		
		public BusPathToTime()
		{
			this._BusPath = default(EntityRef<BusPath>);
			this._Time = default(EntityRef<Time>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusPath_ID")]
		public int BusPath_ID
		{
			get
			{
				return this._BusPath_ID;
			}
			set
			{
				if ((this._BusPath_ID != value))
				{
					if (this._BusPath.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBusPath_IDChanging(value);
					this.SendPropertyChanging();
					this._BusPath_ID = value;
					this.SendPropertyChanged("BusPath_ID");
					this.OnBusPath_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Time_ID")]
		public int Time_ID
		{
			get
			{
				return this._Time_ID;
			}
			set
			{
				if ((this._Time_ID != value))
				{
					if (this._Time.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTime_IDChanging(value);
					this.SendPropertyChanging();
					this._Time_ID = value;
					this.SendPropertyChanged("Time_ID");
					this.OnTime_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BusPath_BusPathToTime", Storage="_BusPath", ThisKey="BusPath_ID", OtherKey="ID", IsForeignKey=true)]
		public BusPath BusPath
		{
			get
			{
				return this._BusPath.Entity;
			}
			set
			{
				BusPath previousValue = this._BusPath.Entity;
				if (((previousValue != value) 
							|| (this._BusPath.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._BusPath.Entity = null;
						previousValue.BusPathToTimes.Remove(this);
					}
					this._BusPath.Entity = value;
					if ((value != null))
					{
						value.BusPathToTimes.Add(this);
						this._BusPath_ID = value.ID;
					}
					else
					{
						this._BusPath_ID = default(int);
					}
					this.SendPropertyChanged("BusPath");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Time_BusPathToTime", Storage="_Time", ThisKey="Time_ID", OtherKey="ID", IsForeignKey=true)]
		public Time Time
		{
			get
			{
				return this._Time.Entity;
			}
			set
			{
				Time previousValue = this._Time.Entity;
				if (((previousValue != value) 
							|| (this._Time.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Time.Entity = null;
						previousValue.BusPathToTimes.Remove(this);
					}
					this._Time.Entity = value;
					if ((value != null))
					{
						value.BusPathToTimes.Add(this);
						this._Time_ID = value.ID;
					}
					else
					{
						this._Time_ID = default(int);
					}
					this.SendPropertyChanged("Time");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Users
	{
		
		private int _ID;
		
		private string _Login;
		
		private string _Password;
		
		private string _Role;
		
		public Users()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Login", CanBeNull=false)]
		public string Login
		{
			get
			{
				return this._Login;
			}
			set
			{
				if ((this._Login != value))
				{
					this._Login = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this._Password = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Role", CanBeNull=false)]
		public string Role
		{
			get
			{
				return this._Role;
			}
			set
			{
				if ((this._Role != value))
				{
					this._Role = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
