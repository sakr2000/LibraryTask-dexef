using AutoMapper;
using LibraryTask_dexef.Shared.Models.Book;
using LibraryTask_dexef.Shared.Models.BorrowedBook;
using LibraryTask_dexef.Shared.Models.User;

namespace LibraryTask_dexef.Application.Common.Mappings
{

    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, AddBookRequest>().ReverseMap();
            CreateMap<Book, UpdateBookRequest>().ReverseMap();

            CreateMap<BorrowedBooks, BorrowedBookDTO>().ReverseMap();
            CreateMap<BorrowedBooks, BorrowBookDTO>().ReverseMap();
            CreateMap<BorrowedBooks, UpdateBorrowedBookDTO>().ReverseMap();


            CreateMap<ApplicationUser, UserSignInRequest>().ReverseMap();
            CreateMap<ApplicationUser, UserSignUpRequest>().ReverseMap();
            CreateMap<ApplicationUser, UserSignInResponse>().ReverseMap();
            CreateMap<ApplicationUser, UserSignUpResponse>().ReverseMap();
            CreateMap<ApplicationUser, UserProfileResponse>().ReverseMap();
        }
    }
}