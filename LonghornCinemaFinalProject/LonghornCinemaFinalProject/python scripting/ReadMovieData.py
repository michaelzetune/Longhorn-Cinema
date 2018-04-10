
def main():
  #read movie data into a file
  in_file = open ("./moviedata.txt", "r")
  out_file = open ("moviedataoutput.txt","w")
  #read movie fields/categories into var
  title = in_file.readline().rstrip()
  #create a title array
  title_list = title.split('\t')

  #fix up title_list
  title_list[4] = 'ReleaseYear'
  title_list[5] = 'Revenue'
  title_list[6] = 'Runtime'
  title_list[7] = 'Tagline'
  title_list[8] = 'MPAArating'
  

  #read rest of data into list
  master_array = []
  #assign an array to temporarily hold each field value for one record
  temp_array = []
  
  #store every record in to a
  
  for x in in_file:
    master_array.append(x.rstrip())

  
  
  

  #iterate through every record and assign it into
  ticker = 1
  for x in master_array:
    temp_array = x.split('\t')
    genrename = temp_array[2].split(,)
    datename = temp_array[4].split(/)
    
    s = ''
    s += "Movie m" + str(ticker) + ' = new Movie();\n' 
    s += 'm' + str(ticker) + '.' + str(title_list[1]) + " = " + "#" + str(temp_array[1]) + "#" + ';\n'
    
    for x in genrename:
      s += 'Genre m' + str(ticker)+ 'g' + str(ticker) = ' new Genre(' +str(x) + "'"');'
    s += 'm' + str(ticker) +'Genres.Add(m' + str(ticker) + 'g' + str(ticker) + ');'

    
    s += 'm' + str(ticker) + '.' + str(title_list[3]) + " = " + "#" + str(temp_array[3]) + "#" + ';\n'
    # year, month, day
    #current month day year
    s += 'm' + str(ticker) + '.' + str(title_list[4]) + " = new DateTime(" + str(datename[2]) + ','+ str(datename[0]) + ',' + str(datename[1])')' + ';\n'
    s += 'm' + str(ticker) + '.' + str(title_list[5]) + " = " + str(temp_array[5]) + ';\n'
    s += 'm' + str(ticker) + '.' + str(title_list[6]) + " = " + str(temp_array[6]) + ';\n'
    s += 'm' + str(ticker) + '.' + str(title_list[7]) + " = " + "#" + str(temp_array[7])+ "#" + ';\n'
    s += 'm' + str(ticker) + '.' + str(title_list[8]) + " = " + str(temp_array[8]) + ';\n'
    s += 'm' + str(ticker) + '.' + str(title_list[9]) + " = " + str(temp_array[9]) + ';\n'
    s += 'db.Repositories.AddorUpdate(m => m.Title, m' + (str(ticker)) + ');\n'
    s += 'db.SaveChanges();\n'
    s += '\n'
    out_file.write(s)
    ticker += 1
    temp_array = []
    genrename = []


##  x = master_array[0]
##  temp_array = x.split('\t')
##  print(temp_array)
  
  
  in_file.close()
  out_file.close()
main()


