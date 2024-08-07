﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Application.Model
{
    public class EditarContaRequest
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string? senha { get; set; }
        public DateTime dataNascimento { get; set; }
        public string telefone { get; set; }
        public string? cpf { get; set; }

    }
}
