import json
import csv

input_file = open("migrantData.json",'r', encoding='utf-8')
input_data = json.load(input_file)
input_file.close()
#total num of entries: 5334

route_list = []
coordinates_list = []

yr2014_list = []
yr2015_list = []
yr2016_list = []
yr2017_list = []
yr2018_list = []
yr2019_list = []
count = 0

# checking for each unique item in a list
def unique(list):
    unique_list = []
    for x in list:
        if x not in unique_list:
            unique_list.append(x)
    return unique_list

# populating lists with coordinates for that year
for i in input_data:
    route = i["Migration Route"]
    coordinates = i["Location Coordinates"]
    year = i["Reported Year"]
    if route != "":
        route_list.append(route)
    if coordinates != "":
        coordinates_list.append(coordinates)
    if year == 2014 and coordinates != "":
        yr2014_list.append(coordinates)
    if year == 2015 and coordinates != "":
        yr2015_list.append(coordinates)
    if year == 2016 and coordinates != "":
        yr2016_list.append(coordinates)
    if year == 2017 and coordinates != "":
        yr2017_list.append(coordinates)
    if year == 2018 and coordinates != "":
        yr2018_list.append(coordinates)
    if year == 2019 and coordinates != "":
        yr2019_list.append(coordinates)

unique_list = unique(route_list)
count_list = []

for uroute in unique_list:
    count_list.append(0)
    for route in route_list:
        if uroute==route:
            count_list[unique_list.index(uroute)]+=1
route_dict = dict(zip(unique_list,count_list))

list1 = sorted(route_dict, key=route_dict.__getitem__, reverse=True)
list2 = sorted(route_dict.values(), reverse=True)

route_dict = dict(zip(list1,list2))
#print(route_dict)
# with open('coordinates/json/2016-coordinates.json', 'w') as fp:
#     json.dump(yr2016_list, fp)
# with open('coordinates/json/2017-coordinates.json', 'w') as fp:
#     json.dump(yr2017_list, fp)
# with open('coordinates/json/2018-coordinates.json', 'w') as fp:
#     json.dump(yr2018_list, fp)
# with open('coordinates/json/2019-coordinates.json', 'w') as fp:
#     json.dump(yr2019_list, fp)


# for x in yr2014_list:
#     count+=1
#
# print(count)
#
# with open('coordinates/json/2015-coordinates.json', 'w') as fp:
#     json.dump(yr2015_list, fp)

# with open('test.csv', 'w', newline='\n') as myfile:
#      wr = csv.writer(myfile)
#      wr.writerow(yr2014_list)
#dict = sorted(dict, key=dict.get, reverse=True)

# 'Central America to US': 1507,
# 'Central Mediterranean': 499,
# 'Western Mediterranean': 255,
# Eastern Mediterranean': 230,
# Western Balkans': 64,
# Calais to United Kingdom': 51,
# 'Horn Africa to Yemen': 15
# 'Western African': 15
# Italy to France': 9,
# 'Darien Gap': 7,
# 'Dominican Republic to Puerto Rico': 2,
# 'Malaysia to Indonesia': 1,
# 'From Haiti to Dajabon, Dominican Republic': 1,
# 'Caribbean to Central America': 3,
# 'Venezuela to Cura▒ao': 1
