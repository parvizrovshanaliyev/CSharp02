﻿using Blog.Data.Abstract;
using Blog.Data.Concrete.EntityFramework.Context;
using Blog.Data.Concrete.EntityFramework.Repositories;
using System.Threading.Tasks;

namespace Blog.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext _context;
        private CategoryRepository _categoryRepository;
        private CommentRepository _commentRepository;
        private PostRepository _postRepository;
        private RoleRepository _roleRepository;
        private UserRepository _userRepository;

        public UnitOfWork(BlogDbContext context)
        {
            _context = context;
        }

        #region Implementation of IAsyncDisposable

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        #endregion

        #region Implementation of IUnitOfWork

        public IUserRepository Users => _userRepository ?? new UserRepository(_context);
        public IRoleRepository Roles => _roleRepository ?? new RoleRepository(_context);
        public IPostRepository Posts => _postRepository ?? new PostRepository(_context);
        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);
        public ICommentRepository Comments => _commentRepository ?? new CommentRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #endregion
    }
}