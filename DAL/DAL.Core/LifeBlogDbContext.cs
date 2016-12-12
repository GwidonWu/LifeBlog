using BLL.Contract;
using DAL.Entity;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Core
{
    public class LifeBlogDbContext : DbContext, IUnitOfWork
    {
        public LifeBlogDbContext() : base("LifeBlog")
        {
            //每次重新启动总是初始化数据库到最新版本（连接字符串为“LifeBlog”）
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<LifeBlogDbContext, Configuration>("LifeBlog"));
        }

        /// <summary>
        /// 管理员
        /// </summary>
        public DbSet<Admin> Admin { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 相片
        /// </summary>
        public DbSet<Photo> Photos { get; set; }

        public DbSet<FileLibrary> FileLibraries { get; set; }

        public DbSet<Album> Albums { get; set; }

        /// <summary>
        /// 系统日志
        /// </summary>
        public DbSet<SysLog> SysLogs { get; set; }
        #region 栏目

        /// <summary>
        /// 栏目
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// 常规栏目
        /// </summary>
        public DbSet<CategoryGeneral> CategoryGeneral { get; set; }

        /// <summary>
        /// 单页栏目
        /// </summary>
        public DbSet<CategoryPage> CategoryPages { get; set; }

        /// <summary>
        /// 链接栏目
        /// </summary>
        public DbSet<CategoryLink> CategoryLinks { get; set; }

        #endregion

        #region 内容
        /// <summary>
        /// 内容类型
        /// </summary>
        public DbSet<ContentType> ContentTypes { get; set; }
        #endregion

        #region 博客文章

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<TimnAxis> TimnAxis { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<BlogBrowseIP> BlogBrowseIP { get; set; }


        #endregion


        public int Commit()
        {
            return this.SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public async Task<int> CommitAsync()
        {
            return await this.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
