﻿using CAPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CAPNet
{
    /// <summary>
    /// Validates all the subelements of the Resource
    /// </summary>
    public class ResourceValidator : Validator<Info>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        public ResourceValidator(Info info)
            : base(info) { }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return !Errors.Any();
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                return from resource in Entity.Resources
                       from error in GetErrors(resource)
                       select error;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        private static IEnumerable<Error> GetErrors(Resource resource)
        {
            return resource.GetErrorsFromAllEntityValidators();
        }
    }
}
