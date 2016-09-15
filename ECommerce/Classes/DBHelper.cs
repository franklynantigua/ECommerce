﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerce.Models;

namespace ECommerce.Classes
{
    public class DBHelper
    {



        public static Response SaveChanges(ECommerceContext db)
        {
            try
            {
                db.SaveChanges();
                return new Response {Succeded = true,};
            }
            catch (Exception  ex)
            {

                var response = new Response {Succeded = false,};
                if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("_Index"))
                {
                    response.Message = "There is a record with the same value ";
                }

                else if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = "The record can't be delete because it has related records ";
                }

                return response;
            }
        }



        public static  int GetState(string description, ECommerceContext db)
        { 

            var state = db.States.Where(s => s.Description == description).FirstOrDefault();
            if (state == null)
            {
                state=new State{Description = description,};
                db.States.Add(state);
                db.SaveChanges();
            }
            return state.StateId;
        }
    }
}