using EFTReports.Abstract;
using EFTReports.Entities;
using MessageLog;
using libClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTReports.Concrete
{
    public class EFAccess : IAccess
    {

        protected EFDbContext context = new EFDbContext();
        private eventID eventID = eventID.EFTReports_EFAccess;

        public IQueryable<Access> Access
        {
            get { return context.Access; }
        }

        public IQueryable<Access> GetAccess()
        {
            try
            {
                return Access;
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetAccess()"), eventID);
                return null;
            }
        }

        public Access GetAccess(int id)
        {
            try
            {
                return GetAccess().Where(a => a.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetAccess(id={0})", id), eventID);
                return null;
            }
        }

        public Access GetAccess(string controller, string action)
        {
            try
            {
                return GetAccess().Where(a => a.controller.ToLower() == controller.ToLower() & a.action.ToLower() == action.ToLower()).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("GetAccess(controller={0}, action={1})", controller, action), eventID);
                return null;
            }
        }

        public int SaveAccess(Access Access)
        {
            Access dbEntry;
            try
            {
                if (Access.id == 0)
                {
                    dbEntry = new Access()
                    {
                        id = 0,
                        description = Access.description,
                        action = Access.action,
                        controller = Access.controller,
                        roles = Access.roles,
                        users = Access.users
                    };
                    context.Access.Add(dbEntry);
                }
                else
                {
                    dbEntry = context.Access.Find(Access.id);
                    if (dbEntry != null)
                    {
                        dbEntry.description = Access.description;
                        dbEntry.action = Access.action;
                        dbEntry.controller = Access.controller;
                        dbEntry.roles = Access.roles;
                        dbEntry.users = Access.users;
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                e.WriteErrorMethod(String.Format("SaveAccess(Access={0})", Access.GetFieldsAndValue()), eventID);
                return -1;
            }
            return dbEntry.id;
        }

        public Access DeleteAccess(int id)
        {
            Access dbEntry = context.Access.Find(id);
            if (dbEntry != null)
            {
                try
                {
                    context.Access.Remove(dbEntry);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    e.WriteErrorMethod(String.Format("DeleteAccess(id={0})", id), eventID);
                    return null;
                }
            }
            return dbEntry;
        }
    }
}
