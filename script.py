<<<<<<< HEAD
import json

input_file = open("migrantData.json", "r", encoding='utf-8')
input_data = json.load(input_file)
input_file.close()

route_list = []
coordinates_list = []
count = 0

def unique(list):
    unique_list = []
    for x in list:
        if x not in unique_list:
            unique_list.append(x)
    return unique_list

for i in input_data:
    route = i["Migration Route"]
    coordinates = i["Location Coordinates"]
    if route != "":
        route_list.append(route)
    if coordinates != "":
        coordinates_list.append(coordinates)

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

for x in coordinates_list:
    count+=1

print(count)

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

# print(coordinates_list)
# with open('coordinates.json', 'w') as fp:
#     json.dump(coordinates_list, fp)
#
# for i in migrantData:
#     idValue = i["id"]
#     dateValue = i["date"]
#     causeValue = i["cause_of_death"]
#
#     dict = {"date": dateValue[6:],
#             "cause_of_death": causeValue}
#
#     if not (dateValue == "" or causeValue == ""):
#         if(causeValue=="Drowning" or causeValue == "Presumed drowning" or causeValue == "Sickness_and_lack_of_access_to_medicines" or causeValue == "Shot_or_Stabbed" or causeValue == "Vehicle_Accident"):
#             dictList.append(dict)
=======
import json

input_file = open("migrantData.json", "r", encoding='utf-8')
input_data = json.load(input_file)
input_file.close()

route_list = []
coordinates_list = []
count = 0

def unique(list):
    unique_list = []
    for x in list:
        if x not in unique_list:
            unique_list.append(x)
    return unique_list

for i in input_data:
    route = i["Migration Route"]
    coordinates = i["Location Coordinates"]
    if route != "":
        route_list.append(route)
    if coordinates != "":
        coordinates_list.append(coordinates)

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

for x in coordinates_list:
    count+=1

print(count)

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

# print(coordinates_list)
# with open('coordinates.json', 'w') as fp:
#     json.dump(coordinates_list, fp)
#
# for i in migrantData:
#     idValue = i["id"]
#     dateValue = i["date"]
#     causeValue = i["cause_of_death"]
#
#     dict = {"date": dateValue[6:],
#             "cause_of_death": causeValue}
#
#     if not (dateValue == "" or causeValue == ""):
#         if(causeValue=="Drowning" or causeValue == "Presumed drowning" or causeValue == "Sickness_and_lack_of_access_to_medicines" or causeValue == "Shot_or_Stabbed" or causeValue == "Vehicle_Accident"):
#             dictList.append(dict)
>>>>>>> ade2d87e86259d08d021c9f06daf54d1162f2e81
