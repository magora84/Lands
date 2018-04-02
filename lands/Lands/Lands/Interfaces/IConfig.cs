using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Interop;
namespace Lands.Interfaces
{
  public  interface IConfig
    {
         string DirectoryDB { get;  }
        ISQLitePlatform Platform { get; }
    }
}
