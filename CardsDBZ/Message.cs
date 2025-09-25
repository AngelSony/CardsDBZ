using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsDBZ
{
    class Message
    {
        private object _Obj;
        private Type _ObjType;

        public Message() { }
        public Message(object obj, Type type)
        {
            _Obj = obj;
            _ObjType = type;
        }
        public object Obj { get => _Obj; set => _Obj = value; }
        public Type ObjType { get => _ObjType; set => _ObjType = value; }
    }
}
