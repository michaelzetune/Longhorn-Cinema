
def main():
  #read movie data into a file
  in_file = open ("./moviedata.txt", "r")
  out_file = open ("moviedataoutput.txt","w")
  #read movie fields/categories into var
  title = in_file.readline().rstrip()
  #create a title array
  title_list = title.split('\t')

  #fix up title_list
  title_list[4] = 'ReleaseDate'
  title_list[5] = 'Revenue'
  title_list[6] = 'Runtime'
  title_list[7] = 'Tagline'
  title_list[8] = 'MPAARating'
  

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
      

    temp_array[2].lstrip('"')
    if '"' in temp_array[9]:
      temp_array[9].strip('"')
    genrename = temp_array[2].split(',')
    datename = temp_array[4].split('/')
    actorname = temp_array[9].split(',')
    actorname[0] = "q" + actorname[0]

    for x in genrename:
      x = x.replace('"', '')
      x = x.replace(' ', '')

    s = ''
    s += "Movie m" + str(ticker) + ' = new Movie();\n'
    #m1.Title
    s += 'm' + str(ticker) + '.' + str(title_list[1]) + " = " + "\"" + str(temp_array[1]) + "\"" + ';\n'
    #m1.Genres
    ticker2 = 1
    for i in range(len(genrename)):
      genrename[i] = genrename[i].replace('"', '')
      genrename[i] = genrename[i].replace(" ", "")
      s += 'm' + str(ticker)+ '.Genres.Add(db.Genres.FirstOrDefault(x => x.Name == \"' + genrename[i] + '\"));\n'
      ticker2 += 1
    for i in range(len(actorname)):
    	actorname[i] = actorname[i].replace('"', '')
    	actorname[i] = actorname[i][1:]
    #db.Genres.AddOrUpdate
    for y in genrename:
      s += str(y) + '.Movies.Add(db.Movies.FirstOrDefault(x => x.Title == "'+ str(y) + '"));\n'
    #m1.overview
    overview = temp_array[3]
    overview = overview.replace('""', '\\"')
    if overview[0] != "\"":
    	overview = "\"" + overview + "\""
    print("!!overview: " + "@" + overview + "@")
    s += 'm' + str(ticker) + '.' + str(title_list[3]) + " = " + overview + ';\n'
    # year, month, day
    #current month day year
    #m1.RevenueDate
    s += 'm' + str(ticker) + '.' + str(title_list[4]) + " = new DateTime(" + str(datename[2]) + ','+ str(datename[0]) + ',' + str(datename[1]) + ')' + ';\n'
    #m1.Revenue
    s += 'm' + str(ticker) + '.' + str(title_list[5]) + " = " + str(temp_array[5]) + ';\n'
    #m1.Runtime
    s += 'm' + str(ticker) + '.' + str(title_list[6]) + " = " + str(temp_array[6]) + ';\n'
    #m1.Tagline
    tagline = str(temp_array[7])
    if (tagline[0:1] != '"'):
    	tagline = '"' + tagline + '"'
    s += 'm' + str(ticker) + '.' + str(title_list[7]) + " = " + tagline + ';\n'
    #m1.MPAARating = MPAARating.Info;
    s += 'm' + str(ticker) + '.' + str(title_list[8]) + " = MPAARating." + str(temp_array[8]) + ';\n'
    #m1.Actors.Add("info");
    for x in actorname:
      s += 'm' + str(ticker) + '.' + str(title_list[9]) + ".Add(\"" + str(x) + '");\n'
    s += 'db.Movies.AddOrUpdate(m => m.Title, m' + (str(ticker)) + ');\n'
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


