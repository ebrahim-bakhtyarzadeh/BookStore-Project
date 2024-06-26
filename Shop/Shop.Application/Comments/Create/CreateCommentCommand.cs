﻿using Common.Application;

namespace Shop.Application.Comments.Create
{
    public record CreateCommentCommand
        (long UserId, long ProductId, string textComment, string UpdateDate) : IBaseCommand;
}
