﻿using Levva.Newbies.Coins.Logic.Dtos;

namespace Levva.Newbies.Coins.Logic.Interfaces {
    public interface ICategoriaService {
        void Create(CategoriaDto categoria);
        CategoriaDto Get(int Id);
        List<CategoriaDto> GetAll();
        void Update(CategoriaDto categoria);
        void Delete(int Id);
    }
}
