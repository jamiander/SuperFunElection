﻿using SuperFunElection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection.services
{
    public interface ICandidateService
    {
        Task<Candidate> SelectCandidate(int id);
       
    }
}