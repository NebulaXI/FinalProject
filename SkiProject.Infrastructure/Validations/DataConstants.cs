using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Infrastructure.Validations
{
    public class DataConstants
    {
        public class ApplicationUser
        {
            public const int UserMaxFirstName= 40;
            public const int UserMaxLastName= 45;
            public const int UserMinAge = 18;
            public const int UsernameMax = 30;
        }

        public class UserBankCard
        {
            public const int MaxCardHolderName = 50;
        }

        public class Post
        {
            public const int ContentMaxLength = 3500;
        }

        public class ForumTopic
        {
            public const int TitleMaxLength = 100;
        }
    }
}
