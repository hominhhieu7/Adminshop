﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using ShopMVC.Data.Entity;

namespace ShopMVC.Service
{
    public partial interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(Expression<Func<T, bool>> expression);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> expression);

        T GetById(object id);

        bool Insert(T entity);

        bool Insert(IEnumerable<T> entities);

        bool Update(T entity);

        bool Update(IEnumerable<T> entities);
        
        bool UpdateNotSave(T entity);

        bool Delete(object id);

        bool Delete(T entity);

        bool Delete(IEnumerable<T> entities);

        long Count(Expression<Func<T, bool>> expression);

        int CountInt(Expression<Func<T, bool>> expression);

        void Save();
    }

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        internal BANHANG_THUCTAPEntities Context;
        internal DbSet<T> Table;

        public BaseRepository(BANHANG_THUCTAPEntities context)
        {
            this.Context = context;
            this.Table = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Table;
        }
        public virtual T Get(Expression<Func<T, bool>> expression)
        {
            try
            {
                return Table.FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> expression)
        {
            return Table.Where(expression);
        }
        public virtual T GetById(object id)
        {
            return Table.Find(id);
        }
        public virtual bool Insert(T entity)
        {
            bool result;
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Table.Add(entity);
                Context.SaveChanges();
                result = true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //throw fail;
                result = false;
            }
            return result;
        }
        public virtual bool Insert(IEnumerable<T> entities)
        {
            bool result;
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    Table.Add(entity);

                Context.SaveChanges();
                result = true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //throw fail;
                result = false;
            }
            return result;
        }
        public virtual bool Delete(object id)
        {
            bool result;
            try
            {
                if (id == null)
                    throw new ArgumentNullException("id");

                T entityToDelete = Table.Find(id);
                Delete(entityToDelete);
                this.Context.SaveChanges();
                result = true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //throw fail;
                result = false;
            }
            return result;
        }
        public virtual bool Delete(T entityToDelete)
        {
            bool result;
            try
            {
                if (entityToDelete == null)
                    throw new ArgumentNullException("entityToDelete");

                if (Context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    Table.Attach(entityToDelete);
                }
                Table.Remove(entityToDelete);
                this.Context.SaveChanges();
                result = true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //throw fail;
                result = false;
            }
            return result;
        }
        public virtual bool Delete(IEnumerable<T> entities)
        {
            bool result;
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    Table.Remove(entity);

                Context.SaveChanges();
                result = true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //throw fail;
                result = false;
            }
            return result;
        }
        public virtual bool Update(T entityToUpdate)
        {
            bool result;
            try
            {
                if (entityToUpdate == null)
                    throw new ArgumentNullException("entityToUpdate");

                Table.Attach(entityToUpdate);
                Context.Entry(entityToUpdate).State = EntityState.Modified;
                Context.SaveChanges();
                result = true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //throw fail;
                result = false;
            }
            return result;
        }
        public virtual bool Update(IEnumerable<T> entities)
        {
            bool result;
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                Context.SaveChanges();
                result = true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //throw fail;
                result = false;
            }
            return result;
        }
        public virtual bool UpdateNotSave(T entityToUpdate)
        {
            bool result;
            try
            {
                if (entityToUpdate == null)
                    throw new ArgumentNullException("entityToUpdate");

                Table.Attach(entityToUpdate);
                Context.Entry(entityToUpdate).State = EntityState.Modified;
                result = true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //throw fail;
                result = false;
            }
            return result;

        }
        public virtual long Count(Expression<Func<T, bool>> expression)
        {
            return Table.Count(expression);
        }
        public virtual int CountInt(Expression<Func<T, bool>> expression)
        {
            return Table.Count(expression);
        }
        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}
