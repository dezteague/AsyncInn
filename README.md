# LAB13-AsyncInn

 MVC application for Async Inn Hotel management system

## Database Schema

![diagram](https://github.com/dezteague/LAB13-AsyncInn/blob/master/AsyncInn/Assets/databaseSchema.JPG)

### Entities:

Hotels: Hotels have a 1:many relationship with hotel rooms, which means that each hotel can have multiple rooms.

Rooms: Rooms indicates a specific room type that can vary based on layout. A room type can belong to many hotels.  

Amenities: There are a variety of amenities such as air-conditioning, a coffee maker, etc. A room can have many different amenities which is represented in the 1:many relationship.

RoomAmenities: This is a pure join table that has a combination of AmenitiesID and RoomID as a composite key. The many:1 relationship assures that an amenity will only be applied to a room once. 

HotelRoom: This table has a composite key of HotelID and RoomNumber. This allows multiple hotel locations to use the same room number. 

## Usage

1. Clone the repository 
2. Open the AsyncInn solution in Visual Studio
3. Run IIS Express
4. Navigate website in your browser

