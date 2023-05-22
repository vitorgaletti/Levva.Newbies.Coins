﻿using Levva.Newbies.Coins.Business.Dtos;

namespace Levva.Newbies.Coins.Business.Interfaces {
    public interface ITransacaoService {
        void Create(TransacaoDto transacao);
        TransacaoDto Get(int Id);
        List<TransacaoDto> GetAll();
        void Update(TransacaoDto transacao);
        void Delete(int Id);
    }
}