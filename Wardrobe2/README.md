# WARDROBE

Wardrobe is a desktop application that allows you to catalog your clothes, shoes, and accessories, as well as plan and save outfits.

# HIERARCHY

Outfit
> Slot[]
>> Item[]
>>> Rating[]
>>> (props)

Items are comprised of properties for that Item, such as its name, brand, and notes about it, as well as special Ratings, such as how warm it is, or how formal it is. 

Ratings come in several types: Good/Bad, Formality, Wear, Fit, and Warmth. Each is a scale where each step on the scale has a description, such as "Too loose" or "Semi-formal".

Outfits are comprised of slots, one for each place you can wear clothing, essentially, as well as some properties specific to that Outfit configuration. 

Slots are comprised of one or more item, and are basically just containers for that type of item. They know what kind of slot they are, and what item(s) they hold.




