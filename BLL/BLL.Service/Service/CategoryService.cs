using BLL.Contract;
using BLL.Service.Interface;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Service
{
    [Export(typeof(ICategoryService))]
    public class CategoryService : BaseService<Category, int>, ICategoryService
    {


        #region 添加栏目
        /// <summary>
        /// 添加栏目【Code：2-常规栏目信息不完整，3-单页栏目信息不完整，4-链接栏目信息不完整，5-栏目类型不存在】
        /// </summary>
        /// <param name="category">栏目数据【包含栏目类型对应数据】</param>
        /// <returns></returns>
        //public override OperResult Add(Category category)
        //{
        //    return Add(category, new CategoryGeneral() { CategoryID = category.ID, ContentView = "Index", View = "Index" });
        //}

        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="category">基本信息</param>
        /// <param name="general">常规栏目信息</param>
        /// <returns></returns>
        public OperResult Add(Category category, CategoryGeneral general)
        {
            OperResult result = new OperResult() { Code = 1 };
            result = base.Add(category);
            general.CategoryID = category.ID;
            var _generalManager = new CategoryGeneralService();
            _generalManager.Add(general);
            return result;
        }
        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="category">基本信息</param>
        /// <param name="page">单页栏目信息</param>
        /// <returns></returns>
        public OperResult Add(Category category, CategoryPage page)
        {
            OperResult result = new OperResult() { Code = 1 };
            result = base.Add(category);
            page.CategoryID = category.ID;
            var _pageManager = new CategoryPageService();
            _pageManager.Add(page);
            return result;
        }

        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="category">基本信息</param>
        /// <param name="link">链接栏目信息</param>
        /// <returns></returns>
        public OperResult Add(Category category, CategoryLink link)
        {
            OperResult result = new OperResult() { Code = 1 };
            result = base.Add(category);
            link.CategoryID = category.ID;
            var _linkManager = new CategoryLinkService();
            _linkManager.Add(link);
            return result;
        }
        #endregion

        #region 更新栏目

        /// <summary>
        /// 更新栏目
        /// </summary>
        /// <param name="category">栏目</param>
        /// <param name="general">常规信息</param>
        /// <returns></returns>
        public OperResult Update(Category category, CategoryGeneral general)
        {
            OperResult result = new OperResult() { Code = 1 };
            result = base.Update(category);
            if (result.Code == 1)
            {
                general.CategoryID = category.ID;
                var _generalManager = new CategoryGeneralService();
                if (general.ID == 0) result = _generalManager.Add(general);
                else result = _generalManager.Update(general);
            }
            if (result.Code == 1) result.Message = "更新栏目成功！";
            return result;
        }

        /// <summary>
        /// 更新栏目
        /// </summary>
        /// <param name="category">栏目</param>
        /// <param name="page">单页信息</param>
        /// <returns></returns>
        public OperResult Update(Category category, CategoryPage page)
        {
            OperResult result = new OperResult() { Code = 1 };
            result = base.Update(category);
            if (result.Code == 1)
            {
                page.CategoryID = category.ID;
                var _pageManager = new CategoryPageService();
                if (page.ID == 0) result = _pageManager.Add(page);
                else result = _pageManager.Update(page);
            }
            if (result.Code == 1) result.Message = "更新栏目成功！";
            return result;
        }

        /// <summary>
        /// 更新栏目
        /// </summary>
        /// <param name="category">栏目</param>
        /// <param name="link">链接信息</param>
        /// <returns></returns>
        public OperResult Update(Category category, CategoryLink link)
        {
            OperResult result = new OperResult() { Code = 1 };
            result = base.Update(category);
            if (result.Code == 1)
            {
                link.CategoryID = category.ID;
                var _linkManager = new CategoryLinkService();
                if (link.ID == 0) result = _linkManager.Add(link);
                else result = _linkManager.Update(link);
            }
            if (result.Code == 1) result.Message = "更新栏目成功！";
            return result;
        }

        #endregion


        /// <summary>
        /// 查找子栏目
        /// </summary>
        /// <param name="id">栏目ID</param>
        /// <returns></returns>
        public List<Category> FindChildren(int id)
        {
            return Repository.FindList(c => c.ParentID == id, new OrderParam() { Method = OrderMethod.ASC, PropertyName = "Order" }).ToList();
        }

        /// <summary>
        /// 查找根栏目
        /// </summary>
        /// <returns></returns>
        public List<Category> FindRoot()
        {
            return FindChildren(0);
        }

        /// <summary>
        /// 查找栏目路径
        /// </summary>
        /// <param name="id">栏目ID</param>
        /// <returns></returns>
        public List<Category> FindPath(int id)
        {
            List<Category> _categories = new List<Category>();
            var _category = Find(id);
            while (_category != null)
            {
                _categories.Insert(0, _category);
                _category = Find(_category.ParentID);
            }
            return _categories;
        }

        /// <summary>
        /// 查找列表
        /// </summary>
        /// <param name="number">返回数量【0-全部】</param>
        /// <param name="type">栏目类型【null 全部】</param>
        /// <param name="orderParams">【排序参数】</param>
        /// <returns></returns>
        public List<Category> FindList(int number, CategoryType? type, OrderParam[] orderParams)
        {
            List<Category> _categories;
            if (orderParams == null) orderParams = new OrderParam[] { new OrderParam() { Method = OrderMethod.ASC, PropertyName = "ParentPath" }, new OrderParam() { Method = OrderMethod.ASC, PropertyName = "Order" } };
            if (type == null) _categories = base.Repository.FindList(c => true, orderParams, number).ToList();
            else _categories = base.Repository.FindList(c => c.Type == type, orderParams, number).ToList();
            return _categories;

        }
    }
}
