using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Context
{
	public abstract class ModelAbstractContext
	{
		private ModelAbstractContext instance;
		public ModelAbstractContext Instance => instance;
		public ModelAbstractContext()
		{
			if (instance != null) return;
			instance = this;
		}
		protected User UserModel => instance.UserModel;
		protected Category CategoryModel => instance.CategoryModel;
		protected Comment CommentModel => instance.CommentModel;
		protected Image ImageModel => instance.ImageModel;
		protected Product ProductModel => instance.ProductModel;
		protected Role RoleModel => instance.RoleModel;
		protected Store StoreModel => instance.StoreModel;
	}
}
