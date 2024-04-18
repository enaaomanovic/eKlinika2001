using AutoMapper;
using eKlinika.Model.Requests;
using eKlinika.Model.SearchObject;
using eKlinika.Services.Base;
using eKlinika.Services.Context;
using eKlinika.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Services
{
    public class LjekarService: BaseService<Model.Ljekar, Database.Ljekar, LjekarSearchObject, LjekarInsertRequest, LjekarUpdateRequest>, LjekarInterface
    {
        public LjekarService(eKlinikaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        //public override async Task<Model.Ljekar> Insert(LjekarInsertRequest request)
        //{

        //    var entity = _mapper.Map<Database.Ljekar>(request);
        //    _context.Add(entity);


        //    entity.LozinkaSalt = GenerateSalt();
        //    entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
        //    _context.SaveChanges();

        //    return _mapper.Map<Model.Ljekar>(entity);
        //}

        //public static byte[] GenerateSalt()
        //{
        //    var buf = new byte[16];
        //    (new RNGCryptoServiceProvider()).GetBytes(buf);
        //    //   return Convert.ToBase64String(buf);
        //    return buf;
        //}
        //public static byte[] GenerateHash(byte[] src, string password)
        //{

        //    byte[] bytes = Encoding.Unicode.GetBytes(password);
        //    byte[] dst = new byte[src.Length + bytes.Length];

        //    System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
        //    System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

        //    HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
        //    byte[] inArray = algorithm.ComputeHash(dst);
        //    //   return Convert.ToBase64String(inArray);
        //    return inArray;
        //}
        //public Model.Ljekar Authenticiraj(string username, string pass)
        //{
        //    var result = _context.Where(x => x.username == username);
         

        //    var user = result.FirstOrDefault();
        //    if (user != null)
        //    {
        //        var newHash = GenerateHash(user.LozinkaSalt, pass);

        //        if (ByteArrayCompare(newHash, user.LozinkaHash))
        //        {
        //            return _mapper.Map<Model.Ljekar>(user);
        //        }

        //    }
        //    return null;
        //}

        //static bool ByteArrayCompare(byte[] a1, byte[] a2)
        //{
        //    if (a1.Length != a2.Length)
        //        return false;

        //    for (int i = 0; i < a1.Length; i++)
        //        if (a1[i] != a2[i])
        //            return false;

        //    return true;
        //}


    }
}
