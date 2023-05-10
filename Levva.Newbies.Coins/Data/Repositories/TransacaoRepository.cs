using Levva.Newbies.Coins.Data.Repositories.Interfaces;
using Levva.Newbies.Coins.Domain.Models;

namespace Levva.Newbies.Coins.Data.Repositories {
    public class TransacaoRepository : ITransacaoRepository {

        private readonly Context _context;

        public TransacaoRepository(Context context) {
            _context = context;
           
        }

        public void Create(TransacaoDto transacao) {
            _context.Transacao.Add(transacao);
            _context.SaveChanges();
        }

        public TransacaoDto Get(int Id) {
            return _context.Transacao.Find(Id);
        }

        public List<TransacaoDto> GetAll() {
            return _context.Transacao.ToList();
        }

        public void Update(TransacaoDto transacao) {
            _context.Transacao.Update(transacao);
            _context.SaveChanges();
        }

        public void Delete(int Id) {
            var transacao = _context.Transacao.Find(Id);
            _context.Transacao.Remove(transacao);
            _context.SaveChanges();
        }
    }
}
