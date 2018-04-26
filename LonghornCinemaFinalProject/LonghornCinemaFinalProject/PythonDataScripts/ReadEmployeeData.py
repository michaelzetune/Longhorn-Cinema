#ReadUserData
def main():
  #read movie data into a file
  in_file = open ("./EmployeeData.txt", "r")
  out_file = open ("EmployeeDataOutput.txt","w")
  #read movie fields/categories into var
  title = in_file.readline().rstrip()
  #create a title array
  title_list = title.split('\t')

  #title_list[0] = LastName
  #title_list[1] = FirstName
  #title_list[12] = Email
  #title_list[3] = Password
  #title_list[4] = Birthday
  #title_list[7] = Street
  #title_list[8] = City
  #title_list[9] = State
  #title_list[10] = Zipcode
  #title_list[11] = PhoneNumber

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
    s += "User e" + str(ticker) + " = new User();\n"
    #Add last name
    s += "e" + str(ticker) + ".LastName = " + '"' + str(data_list[0])+ '"'  + ";\n"
    #Add first name
    s += "e" + str(ticker) + ".FirstName = " +  '"' + str(data_list[1]) + '"' + ";\n"
    #Add email
    s += "e" + str(ticker) + ".Email = "  + '"' + str(data_list[12]) +  '"' + ";\n"
    #Add Password
    s += "e" + str(ticker) + ".Password = " +  '"' + str(data_list[3]) + '"' + ";\n"
    #Add Birthday
    #######################
    date_list = data_list[4].split("/")
    s += "e" + str(ticker) + ".Birthday = " + 'new DateTime(' + str(date_list[2]) + "," + str(date_list[0]) + "," + str(date_list[1]) + ')' + ";\n"
    #####################
    #Add Street Address
    s += "e" + str(ticker) + ".StreetAddress = " + '"' + str(data_list[7]) + '"'  + ";\n"
    #Add City
    s += "e" + str(ticker) + ".City = " + '"' + str(data_list[8]) + '"' + ";\n"
    #Add State
    s += "e" + str(ticker) + ".State = "  + '"' + str(data_list[9]) + '"' + ";\n"
    #Add zipcode
    s += "e" + str(ticker) + ".ZipCode = " + str(data_list[10]) + ";\n"
    #Phone Number
    s += "e" + str(ticker) + ".PhoneNumber = "  + '"' + str(data_list[11]) + '"' + ";\n"
    #Popcorn Points
    s += "e" + str(ticker) + ".PopcornPointsBalance = 0;\n"
    #Add or Update Line
    s += "db.Users.AddOrUpdate( e => e.LastName, e" + str(ticker) + ");\n"
    #Database Save changes line
    s += "db.SaveChanges();\n"
    s += '\n'
    out_file.write(s)
    ticker += 1
    
  in_file.close()
  out_file.close()
main()
    

    
      

    
