
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Restoran.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AspNetUserLogin
{
    [Key, Column(Order=0)]
    public string LoginProvider { get; set; }

    [Key, Column(Order=1)]
    public string ProviderKey { get; set; }

    [Key, Column(Order=2)]
    public string UserId { get; set; }



    public virtual AspNetUser AspNetUser { get; set; }

}

}
