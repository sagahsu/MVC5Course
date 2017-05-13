using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        /// <summary>
        /// �мgAll(),��������ALL���令�u�����O�R�������
        /// </summary>
        /// <returns></returns>
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => !p.isDeleted.Value);//�мgAll(),��������ALL���令�u�����O�R�������
        }

        /// <summary>
        /// ���ѷs����All(bool showAll)
        /// </summary>
        /// <param name="showAll"></param>
        /// <returns></returns>
        public IQueryable<Product> All(bool showAll)
        {
            if (showAll)
            {
                return base.All();
            }
            else
            {
                return this.All();
            }
        }

        public IQueryable<Product> findAll()
        {
            return this.All();
        }

        public Product findByProductId(int id)
        {
            return this.All().FirstOrDefault(p=>p.ProductId == id);
        }

        public IQueryable<Product> GetProduct�C���Ҧ����(bool Active, bool showAll = false)//optional �Ѽ�
        {
            IQueryable<Product> all = this.All();
            if (showAll)
            {
                all = base.All();
            }
            return all
                 .Where(p => p.Active.HasValue && p.Active.Value == Active)
                 .OrderByDescending(p => p.ProductId).Take(10);
        }

        public void Update(Product product)
        {
            this.UnitOfWork.Context.Entry(product).State = EntityState.Modified;
        }

        public override void Delete(Product product)
        {
            product.isDeleted = true;
        }

        public int Create(Product product)
        {
            return Create(product);
        }

    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}