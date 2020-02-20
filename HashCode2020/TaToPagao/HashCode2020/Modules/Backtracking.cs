using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashCode2019.Modules
{
    public class Backtracking<Escenario>
        where Escenario : IEnumerable
    {
        private int _numCol = -1; //base 0
        private Escenario _escenario;
        private List<(dynamic Metodo, (Type Type, Tipo Tipo) TipoParametro)> _implementaciones;
        private dynamic _iteraccion;
        private List<(Type Type, Tipo Tipo)> _tipos;
        private Type _typeIteraccion;

        public Backtracking(Escenario escenario)
        {
            _escenario = escenario;
            var enumerator = escenario.GetEnumerator();
            while (enumerator.MoveNext()){ ++_numCol; }
        }

        private bool Validar(Escenario escenario, object elemento)
        {
            var tipoParametro = _tipos.Single(x => x.Tipo == Tipo.CONDICION_ESCENARIO).Type;
            var enumerator = escenario.GetEnumerator();
            object anterior = null;
            bool result;

            while (enumerator.MoveNext())
            {
                if (anterior is null)
                {
                    anterior = enumerator.Current;
                    continue;
                }

                foreach (var metodoYtipo in _implementaciones.Where(x => x.TipoParametro.Tipo == Tipo.CONDICION_ESCENARIO || x.TipoParametro.Tipo == Tipo.CONDICION_ELEMENTO))
                {
                    if (metodoYtipo.TipoParametro.Tipo == Tipo.CONDICION_ELEMENTO)
                        result = metodoYtipo.Metodo(Convert.ChangeType(enumerator.Current, metodoYtipo.TipoParametro.Type), Convert.ChangeType(anterior, metodoYtipo.TipoParametro.Type));

                    else
                        result = metodoYtipo.Metodo(Convert.ChangeType(enumerator.Current, metodoYtipo.TipoParametro.Type), _escenario);

                    if (result)
                        return result;
                }             

                //Actualizamos anterior.
                anterior = enumerator.Current;
            }

            return false;
        }

        public Backtracking<Escenario> AñadirCondición<T, Val>(Func<T, T, bool> condicion)
            where T : ItemtBacktracking<Val>
        {
            AddType(typeof(T), Tipo.CONDICION_ELEMENTO);
            _implementaciones.Add((condicion, (typeof(T), Tipo.CONDICION_ELEMENTO)));
            return this;
        }

        public Backtracking<Escenario> AñadirCondición<T, Val>(Func<T, Escenario, bool> condicion)
            where T : ItemtBacktracking<Val>
        {
            AddType(typeof(T), Tipo.CONDICION_ESCENARIO);
            _implementaciones.Add((condicion, (typeof(T), Tipo.CONDICION_ESCENARIO)));
            return this;
        }

        public Backtracking<Escenario> AñadirIteraccion<T, Val>(Action<T> accion)
        {
            _implementaciones.Add((accion, (typeof(T), Tipo.ITERACCION)));
            _iteraccion = accion;
            return this;
        }

        public List<ResultBacktracking<Escenario>> Resolver<T>(Func<T, bool> condicion = null)
        {
            AddType(typeof(T), Tipo.RESOLUCION);
            var enumerator = _escenario.GetEnumerator();
            object elemento = null;

            while (enumerator.MoveNext())
            {
                elemento = enumerator.Current;
                _iteraccion(Convert.ChangeType(elemento, _typeIteraccion));

                if (Validar(_escenario, elemento))
                {
                    //_escenario
                }

            }
            throw new Exception();
        }

        private Escenario Solucion(int numPaso)
        {
            throw new Exception();
        }

        private void AddType(Type type, Tipo tipo)
        {
            if (_tipos.Any(x => x.Tipo == tipo))
                _tipos.RemoveAll(x => x.Tipo == tipo);

            _tipos.Add((type, tipo));
        }

        private enum Tipo
        {
            CONDICION_ESCENARIO,
            CONDICION_ELEMENTO,
            ITERACCION,
            RESOLUCION

        }
    }

    public class ResultBacktracking<T>
    {
        public T result;
    }

    public interface ItemtBacktracking<T> // T posible delegado
    {
        T Condicionante { get; set; }
        int Indice { get; set; }
    }
}
