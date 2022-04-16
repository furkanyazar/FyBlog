using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
			builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

			builder.RegisterType<BlogManager>().As<IBlogService>().SingleInstance();
			builder.RegisterType<EfBlogDal>().As<IBlogDal>().SingleInstance();

			builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();
			builder.RegisterType<EfCommentDal>().As<ICommentDal>().SingleInstance();

			builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
			builder.RegisterType<EfUserdal>().As<IUserDal>().SingleInstance();

			builder.RegisterType<WriterManager>().As<IWriterService>().SingleInstance();
			builder.RegisterType<EfWriterDal>().As<IWriterDal>().SingleInstance();

			builder.RegisterType<NewsletterManager>().As<INewsletterService>().SingleInstance();
			builder.RegisterType<EfNewsletterDal>().As<INewsletterDal>().SingleInstance();

			builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
			builder.RegisterType<EfAboutDal>().As<IAboutDal>().SingleInstance();

			builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
			builder.RegisterType<EfContactDal>().As<IContactDal>().SingleInstance();
		}
	}
}
