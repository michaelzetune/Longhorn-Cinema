#ReadUserData
def main():
  #read movie data into a file
  in_file = open ("./CustomersData.txt", "r")
  out_file = open ("CustomerDataOutput.txt","w")
  #read movie fields/categories into var
  title = in_file.readline().rstrip()
  #create a title array
  title_list = title.split('\t')

  #title_list[0] = Customer
  #title_list[1] = Password
  #title_list[2] = LastName
  #title_list[3] = FirstName
  #title_list[5] = Birthday
  #title_list[6] = Street
  #title_list[7] = City
  #title_list[8] = State
  #title_list[9] = Zipcode
  #title_list[11] = PhoneNumber
  #title_list[12] = Email
  #title_list[13] = Customer

  #Create a master list to input all of data
  master_array = []

  #Create a data list to further organize data by index
  data_list = []
  

  for x in in_file:
    master_array.append(x.rstrip())

  #create a ticker to help output each object of data correctly
  ticker = 1
  #iterate through every record of data
  for x in master_array:
    s = ""
    #Organize each record of data by seperating them by space into an organized list
    data_list = x.split('\t')
    #Create first line for every user
    s += "User c" + str(ticker) + " = new User();\n"
    #Add last name
    s += "c" + str(ticker) + ".LastName = " + '"' + str(data_list[2])+ '"'  + ";\n"
    #Add first name
    s += "c" + str(ticker) + ".FirstName = " +  '"' + str(data_list[3]) + '"' + ";\n"
    #Add email
    s += "c" + str(ticker) + ".Email = "  + '"' + str(data_list[12]) +  '"' + ";\n"
    #Add Password
    s += "c" + str(ticker) + ".Password = " +  '"' + str(data_list[1]) + '"' + ";\n"
    #Add Birthday
    #######################
    date_list = data_list[5].split("/")
    s += "c" + str(ticker) + ".Birthday = " + 'new DateTime(' + str(date_list[2]) + "," + str(date_list[0]) + "," + str(date_list[1]) + ')' + ";\n"
    #####################
    #Add Street Address
    s += "c" + str(ticker) + ".StreetAddress = " + '"' + str(data_list[6]) + '"'  + ";\n"
    #Add City
    s += "c" + str(ticker) + ".City = " + '"' + str(data_list[7]) + '"' + ";\n"
    #Add State
    s += "c" + str(ticker) + ".State = "  + '"' + str(data_list[8]) + '"' + ";\n"
    #Add zipcode
    s += "c" + str(ticker) + ".ZipCode = " + str(data_list[9]) + ";\n"
    #Phone Number
    s += "c" + str(ticker) + ".PhoneNumber = "  + '"' + str(data_list[11]) + '"' + ";\n"
    #Popcorn Points
    s += "c" + str(ticker) + ".PopcornPointsBalance = " + str(data_list[13]) + ";\n"
    #Add or Update Line
    s += "db.Users.AddOrUpdate( c => c.LastName, c" + str(ticker) + ");\n"
    #Database Save changes line
    s += "db.SaveChanges();\n"
    s += '\n'
    out_file.write(s)
    ticker += 1
   
    
  in_file.close()
  out_file.close()
main()
    

    
      

    
