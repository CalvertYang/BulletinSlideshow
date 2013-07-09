using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace BulletinSlideshow.Models
{
    #region Member
    public class MemberConfigurations : EntityTypeConfiguration<Member>
    {
        public MemberConfigurations()
        {
            // Fluent API 設定建置在此
        }
    }
    #endregion

    #region Category
    public class CategoryConfigurations : EntityTypeConfiguration<Category>
    {
        public CategoryConfigurations()
        {
            // Fluent API 設定建置在此
        }
    }
    #endregion

    #region Information
    public class InformationConfigurations : EntityTypeConfiguration<Information>
    {
        public InformationConfigurations()
        {
            // Fluent API 設定建置在此
        }
    }
    #endregion
}