using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthService>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<AuthorService>().As<IAuthorService>().SingleInstance();
            builder.RegisterType<EfAuthorDal>().As<IAuthorDal>().SingleInstance();

            builder.RegisterType<BookService>().As<IBookService>().SingleInstance();
            builder.RegisterType<EfBookDal>().As<IBookDal>().SingleInstance();

            builder.RegisterType<PublisherService>().As<IPublisherService>().SingleInstance();
            builder.RegisterType<EfPublisherDal>().As<IPublisherDal>().SingleInstance();
        }
    }
}
