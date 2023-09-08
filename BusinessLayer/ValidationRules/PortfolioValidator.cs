﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adı boş bırakılamaz.");
            RuleFor(x => x.ImageURL).NotEmpty().WithMessage("Görsel alanı boş bırakılamaz.");
            RuleFor(x => x.ImageURL2).NotEmpty().WithMessage("Görsel alanı boş bırakılamaz.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alanı boş bırakılamaz.");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Değer alanı boş bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje adı en az 5 karakterden oluşmak zorundadır.");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Proje adı en fazla 100 karakterden oluşmak zorundadır.");
        }
    }
}
