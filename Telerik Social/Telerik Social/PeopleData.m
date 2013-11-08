//
//  PeopleData.m
//  Telerik Social
//
//  Created by Stanimir Karoserov on 07.11.13.
//  Copyright (c) 2013 г. Telerik. All rights reserved.
//

#import "PeopleData.h"

@implementation PeopleData {
    NSArray* _people;
}

- (id)init
{
    self = [super init];
    if (self) {
        _people = @[
                    @{
                        @"name": @"Kiril Nikolov",
                        @"email": @"kiril.nikolov@telerik.com",
                        @"team":@"Kendo UI",
                        @"phone": @"+359887405602"
                        },
                    @{
                        @"name": @"Georgi Mateev",
                        @"email": @"Georgi.Mateev@telerik.com",
                        @"team": @"Sitefinity",
                        @"phone": @"+359887546981"
                        },
                    @{
                        @"name": @"Viktor Bukurov",
                        @"email": @"viktor.bukurov@telerik.com",
                        @"team": @"Sitefinity",
                        @"phone": @"+359887549181"
                        },
                    @{
                        @"name": @"Alexander Vakrilov",
                        @"email": @"alexander.vakrilov@telerik.com",
                        @"team": @"XAML",
                        @"phone": @"+359895657439"
                        },
                    @{
                        @"name": @"Stanimir Karoserov",
                        @"email": @"stanimir.karoserov@telerik.com",
                        @"team": @"xPlatCore",
                        @"phone": @"+359896895148"
                        },
                    @{
                        @"name": @"Petya Bogdanova",
                        @"email": @"petya.bogdanova@telerik.com",
                        @"team": @"Sales",
                        @"phone": @"+359889147648"
                        },
                    @{
                        @"name": @"Nikola Irinchev",
                        @"email": @"nikola.irinchev@telerik.com",
                        @"team": @"Icenium",
                        @"phone": @"+359896942848"
                        },
                    @{
                        @"name": @"Yordan Dimitrov",
                        @"email": @"yordan.dimitrov@telerik.com",
                        @"team": @"Team Puls",
                        @"phone": @"+359896895865"
                        },
                    @{
                        @"name": @"Svetozar Georgiev",
                        @"email": @"svetozar.georgiev@telerik.com",
                        @"team": @"CEO",
                        @"phone": @"+359896111777"
                        },
                    @{
                        @"name": @"Todd Anglin",
                        @"email": @"todd.anglin@telerik.com",
                        @"team": @"VP",
                        @"phone": @"+1564753247"
                        },
                    @{
                        @"name": @"Mihail Valkov",
                        @"email": @"mihail.valkov@telerik.com",
                        @"team": @"Dev. Manager",
                        @"phone": @"+359887584263"
                        },
                    @{
                        @"name": @"Steve Forte",
                        @"email": @"Steve.Forte@telerik.com",
                        @"team": @"CSO",
                        @"phone": @"+156474545"
                        },
                    @{
                        @"name": @"Doug Laird",
                        @"email": @"doug.laird@telerik.com",
                        @"team": @"CMO",
                        @"phone": @"+155584756"
                        }
                    ];
  
    }
    return self;
}

- (void)addPersonTo:(NSMutableArray *)people data:(NSDictionary *)data
{
    [people addObject:data];
}

- (BOOL)containsString:(NSString *)subString inString:(NSString *)string
{
    NSRange range = [string rangeOfString:subString options:NSCaseInsensitiveSearch];
    return (range.location != NSNotFound);
}

- (NSArray *)peopleForFilter:(NSString *)filter
{
    if (0 == filter.length)
        return _people;
    
    NSMutableArray* people = [[NSMutableArray alloc] init];
    
    for (NSDictionary* data in _people) {
        if ([self containsString:filter inString:data[@"name"]] ||
            [self containsString:filter inString:data[@"team"]]) {
            [self addPersonTo:people data:data];
        }
    }
    
    return people;
}

@end
