﻿using Application.Abstract;
using Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samples.Commands.CreateSampleInt
{
    public record CreateSampleIntCommand(
        Guid VariableId,
        int Value) : ICommand<SampleInt>;
}
