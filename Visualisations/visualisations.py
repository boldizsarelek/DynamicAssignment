import plotly.graph_objects as go
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
import packaging

table = pd.read_csv('Results.csv', delimiter=";")
table_pairs = table.query("Matched==1")

sns.set_style("white")
g = sns.displot(table_pairs["ApplicantPreference2"], binwidth=1)

plt.show()

table_sorted = table.query("ApplicantPreference2 <= 3 & ApplicantID2 <5")
print(table_sorted)
source = table_sorted['ApplicantID2']
target = table_sorted['ReceiverID2']
value = table_sorted['ApplicantPreference2']

print(source)
link = dict(source = source, target = target, value = value)
data = go.Sankey(link = link)
fig = go.Figure(data)
