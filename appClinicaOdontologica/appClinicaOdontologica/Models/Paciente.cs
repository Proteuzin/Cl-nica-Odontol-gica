using System;
using System.Collections.Generic;

namespace appClinicaOdontologica.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public string NomeCompleto { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    public virtual ICollection<Procedimento> Procedimentos { get; set; } = new List<Procedimento>();
}
