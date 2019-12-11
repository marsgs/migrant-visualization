import json
import csv
import script

input_file = open("migrantData.json",'r', encoding='utf-8')
input_data = json.load(input_file)
input_file.close()

causeList = []
uniqueCause = []
causesNewDefList = []

#generalizing causes of death
def deathCauseReplacement(input_data):
    for i in input_data:
        cause = i["Cause of Death"]
        #Health Condition
        if "Sickness" in cause or "sickness" in cause or "cancer" in cause or "bleeding" in cause or "Organ" in cause or "Coronary" in cause or "Envenomation" in cause or "Post-partum" in cause or "Respiratory" in cause or "Hypoglycemia" in cause:
            cause = "Health Condition"
        #Harsh Conditions
        elif "Harsh conditions""harsh conditions" in cause or "Harsh weather" in cause or "hearsh weather" in cause or "Exhaustion" in cause or "Heat stroke" in cause:
            cause = "Harsh Conditions"
        #Unknown
        elif "Unknown" in cause or "unknown" in cause:
            cause = "Unknown"
        #Starvation
        elif "Starvation" in cause:
            cause = "Starvation"
        #Dehydration
        elif "Dehydration" in cause:
                cause = "Dehydration"
        #Drowning
        elif "Drowning" in cause or "drowning" in cause or "Pulmonary" in cause or "Respiratory" in cause or "Pneumonia" in cause:
                cause = "Drowning"
        #Hyperthermia
        elif "Hyperthermia" in cause or "hyperthermia" in cause:
                cause = "Hyperthermia"
        #Hypothermia
        elif "Hypothermia" in cause or "hypothermia" in cause:
                cause = "Hypothermia"
        #Asphyxiation
        elif "Asphyxiation" in cause or "asphyxiation" in cause or "Suffocation" in cause:
                cause = "Asphyxiation"
        #Vehicle Accident
        elif "Train" in cause or "train" in cause or "Bus" in cause or "bus" in cause or "vehicle" in cause or "Vehicle" in cause or "truck" in cause or "Truck" in cause or "boat" in cause or "Boat" in cause or "Plane" in cause or "Car" in cause or "car" in cause or "helicopter" in cause:
                cause = "Vehicle Accident"
        #Murdered
        elif "Murder" in cause or "murder" in cause or "murdered" in cause or "Murdered" in cause or "shot" in cause or "Shot" in cause or "Violence" in cause or "violence" in cause or "Hanging" in cause or "mortar" in cause or "landmine" in cause or "Rape" in cause or "Gassed" in cause:
                cause = "Murdered"
        #Crushed
        elif "Rockslide" in cause or "Crushed" in cause or "Crush" in cause:
                cause = "Crushed"
        #Burned
        elif "burns" in cause or "Burned" in cause or "Suffocation" in cause or "fire" in cause or "Fire" in cause:
                cause = "Burned"
        #Electrocution
        elif "Electrocution" in cause:
                cause = "Electrocution"
        #Fallen
        elif "Fall" in cause:
                cause = "Fallen"
        #Killed by animals
        elif "hippopotamus" in cause or "crocodile" in cause:
                cause = "Killed by animals"
        #Exposure
        elif "Exposure" in cause:
                cause = "Exposure"
        i["Cause of Death"] = cause

deathCauseReplacement(input_data)

#Causes of Death
for i in input_data:
    region = i["Region of Incident"]
    year = i["Reported Year"]
    cause = i["Cause of Death"]
    #print(cause)
    if year == 2018:
        causeList.append(cause)

countList = []
for ucause in uniqueCause:
    countList.append(0)
    for cause in causeList:
        if ucause==cause:
            countList[uniqueCause.index(ucause)]+=1

causesDict = dict(zip(uniqueCause,countList))
list1 = sorted(causesDict, key=causesDict.__getitem__, reverse=True)
list2 = sorted(causesDict.values(), reverse=True)
causeDict = dict(zip(list1,list2))
#print(sorted(countList, reverse = True))
#print(causeDict)

#concatinating values to paste in c# for unity
code = "public Dictionary<string, int> causes = new Dictionary<string, int>();\n"
for thing in causeDict:
    code+= "causes.Add(\"" + thing + "\"," + str(causeDict[thing]) + ");\n"
# print(code)

### Total dead and missing by gender and age
childrenList = []
femaleList = []
maleList = []

for i in input_data:
    totalDeadAndMissing = i["Total Dead and Missing"]
    numFemales = i["Number of Females"]
    numMales = i["Number of Males"]
    numChildren = i["Number of Children"]
    if totalDeadAndMissing != "" and numFemales != "" and numMales != "" and numChildren != "":
        childrenList.append(numChildren)
        femaleList.append(numFemales)
        maleList.append(numMales)

sumChild = sum(childrenList)
sumFemale = sum(femaleList)
sumMale = sum(maleList)
